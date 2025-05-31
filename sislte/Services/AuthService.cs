using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using sislte.DTOs;
using sislte.Exceptions;
using sislte.Models;

namespace sislte.Services;

public class AuthService(IStudentRepository studentRepository, IConfiguration config)
    : IAuthService
{
    public string Register(RegisterDto dto)
    {
        if (studentRepository.GetByEmail(dto.Email) != null)
            throw new StudentAlreadyExistsException(dto.Email);

        if (dto.Password != dto.ConfirmPassword)
            throw new StudentInvalidCredentialsException();

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new Student
        {
            Email = dto.Email,
            Password = hashedPassword
        };

        try
        {
            studentRepository.Add(user);
        }
        catch (Exception ex)
        {
            throw new StudentException(ex.Message);
        }

        return GenerateToken(user);
    }

    public string Login(LoginDto dto)
    {
        var student = studentRepository.GetByEmail(dto.Email);
        if (student == null || !BCrypt.Net.BCrypt.Verify(dto.Password, student.Password))
            throw new StudentInvalidCredentialsException();
        
        return GenerateToken(student);
    }
    
    public string GenerateToken(Student student)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["Jwt:Key"]));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, student.Email.ToString()),
            new Claim(ClaimTypes.Role, "Student")
        };

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
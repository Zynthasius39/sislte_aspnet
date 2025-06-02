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
            Password = hashedPassword,
            AvatarURL = "/avatars/default.png",
            DetailedStudent = new DetailedStudent
            {
                Transcript = new Transcript
                {
                    StudentCourseProgram = new StudentCourseProgram
                    {
                        Code = "TEST",
                        Name = "TEST",
                        Lang = "EN",
                    },
                },
                Advisor = new Advisor
                {
                    Email = "adssad",
                    Password = "adssad",
                    FullName = "SDFFDSA",
                },
                FullName = "asdasdssda",
                BirthDate = DateOnly.FromDateTime(new DateTime(1999, 09, 10)),
                EntranceDate = DateOnly.FromDateTime(new DateTime(2020, 05, 01)),
                GraduateDate = DateOnly.FromDateTime(new DateTime(2024, 05, 01)),
                EarnedCredits = 30,
                Education = "adssda",
                Phone = "911",
                EmergencyPhone = "911",
                Gpa = 3.97,
                Loans = 0,
                Location = "sdaasd",
            }
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
            new Claim(ClaimTypes.NameIdentifier, student.Email),
            new Claim(ClaimTypes.Role, student.Role.ToString())
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
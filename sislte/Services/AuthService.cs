using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using sislte.DTOs;
using sislte.Exceptions;
using sislte.Models;
using sislte.Repositories;

namespace sislte.Services;

public class AuthService(IStudentRepository studentRepository, IHttpContextAccessor httpContextAccessor, IConfiguration config)
    : IAuthService
{
    public async Task<string> Register(RegisterDto dto)
    {
        if (await studentRepository.GetByEmailAsync(dto.Email, false) != null)
            throw new StudentAlreadyExistsException(dto.Email);

        if (dto.Password != dto.ConfirmPassword)
            throw new StudentInvalidCredentialsException();

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var student = new Student
        {
            Email = dto.Email,
            Password = hashedPassword,
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
            await studentRepository.AddAsync(student);
        }
        catch (Exception ex)
        {
            throw new StudentException(ex.Message);
        }

        return GenerateToken(student);
    }

    public async Task<string> Login(LoginDto dto)
    {
        var student = await studentRepository.GetByEmailAsync(dto.Email, false);

        if (student == null || !BCrypt.Net.BCrypt.Verify(dto.Password, student.Password))
            throw new StudentInvalidCredentialsException();

        return GenerateToken(student);
    }

    public async Task<Student?> GetCurrentStudentAsync()
    {
        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext == null)
            return null;

        var userClaims = httpContext.User;
        if (userClaims?.Identity?.IsAuthenticated != true)
            return null;

        var emailClaim = userClaims.FindFirst("sub") ?? userClaims.FindFirst(ClaimTypes.NameIdentifier);
        if (emailClaim == null)
            return null;

        var user = await studentRepository.GetByEmailAsync(emailClaim.Value, true);
        return user;
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
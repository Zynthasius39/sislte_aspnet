using sislte.DTOs;
using sislte.Models;

namespace sislte.Services;

public interface IAuthService
{
    Task<string> Register(RegisterDto dto);
    Task<string> Login(LoginDto dto);
    Task<Student?> GetCurrentStudentAsync();
    string GenerateToken(Student student);
}

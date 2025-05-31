using sislte.DTOs;
using sislte.Models;

namespace sislte.Services;

public interface IAuthService
{
    string Register(RegisterDto dto);
    string Login(LoginDto dto);
    string GenerateToken(Student student);
}

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace sislte.Models;

public class Login
{
    private string _password;
    
    [Required]
    public string StudentID { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password
    {
        get => _password;
        set
        {
            using (var sha256 = SHA256.Create())
                _password = Convert.ToHexString(sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value)));
        }
    }

    public bool RememberMe { get; set; }

    public override string ToString()
    {
        return $"StudentID={StudentID}, Password={Password}, RememberMe={RememberMe}";
    }
}
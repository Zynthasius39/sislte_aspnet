using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace sislte.Models;

public class Register
{
    [Required]
    public string StudentID { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public override string ToString() => $"StudentID: {StudentID}, Email: {Email}, Password: {Password}, ConfirmPassword: {ConfirmPassword}";
}
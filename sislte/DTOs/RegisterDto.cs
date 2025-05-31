using System.ComponentModel.DataAnnotations;

namespace sislte.DTOs;

public class RegisterDto
{
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, MinLength(6)] public string Password { get; set; }

    [Required, MinLength(6)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
}
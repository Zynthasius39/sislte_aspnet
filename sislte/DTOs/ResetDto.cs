using System.ComponentModel.DataAnnotations;

namespace sislte.DTOs;

public class ResetDto
{
    [Required, EmailAddress]
    public string Email { get; set; }
}
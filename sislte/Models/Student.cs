using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sislte.Models;

public class Student
{
    public int Id { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }

    [Required] public Role Role { get; set; } = Role.PreservedStudent;
    [Required] public string AvatarURL { get; set; }
    public DetailedStudent? DetailedStudent { get; set; }
}
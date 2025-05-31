using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sislte.Models;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? FullName { get; set; }
    [Required, MaxLength(100)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string Role { get; set; } = "PreservedStudent";
    public string? AvatarURL { get; set; }
    public string? Program { get; set; }
    public double? Gpa { get; set; }
    public int? CoursesCount { get; set; }
    public int? FriendsCount { get; set; }
    public string? Education { get; set; }
    public string? Location { get; set; }
    public string? Skills { get; set; }
    public string? Notes { get; set; }
}
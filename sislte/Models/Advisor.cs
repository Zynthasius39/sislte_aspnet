using System.ComponentModel.DataAnnotations;

namespace sislte.Models;

public class Advisor
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FullName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public ICollection<DetailedStudent> AdvisedStudents { get; set; }
}
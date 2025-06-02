using System.ComponentModel.DataAnnotations;

namespace sislte.Models;

public class CourseProgram
{
    public int Id { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Lang { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
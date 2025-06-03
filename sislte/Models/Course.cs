using System.ComponentModel.DataAnnotations;

namespace sislte.Models;

public class Course
{
    [Key] public int Id { get; set; }
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Theory { get; set; }
    [Required]
    public int Ects { get; set; }

}
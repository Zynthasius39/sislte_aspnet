using System.ComponentModel.DataAnnotations;

namespace sislte.Models;

public class StudentCourseProgram
{
    public int Id { get; set; }
    public int TranscriptId { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Lang { get; set; }
    public ICollection<StudentSemester> StudentSemesters { get; set; } = new List<StudentSemester>();
    public Transcript Transcript { get; set; }
}
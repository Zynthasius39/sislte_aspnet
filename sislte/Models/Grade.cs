using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sislte.Models;

public class Grade
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int StudentSemesterId { get; set; }
    public int Act1 { get; set; }
    public int Act2 { get; set; }
    public int Att { get; set; }
    public int Iw { get; set; }
    public int Final { get; set; }
    public int Sum { get; set; }
    public string Mark { get; set; }
    public Course Course { get; set; }
    public ICollection<AttendanceEntry> AttendanceEntries { get; set; }
    public StudentSemester StudentSemester { get; set; }

}

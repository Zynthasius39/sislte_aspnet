using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sislte.Models;

public class Transcript
{
    public int Id { get; set; }
    public int DetailedStudentId { get; set; }
    public double? Gpa { get; set; }
    public int? Tatc { get; set; }
    public int? Tacc { get; set; }
    public int? Sac { get; set; }
    public StudentCourseProgram StudentCourseProgram { get; set; }
    public DetailedStudent DetailedStudent { get; set; }

    // public static Transcript GetExampleTranscript()
    // {
    //     var semesters = new List<Semester>();
    //     for (var i = 0; i < 6; i++)
    //         semesters.Insert(0, Semester.GetExampleSemester());
    //     return new Transcript()
    //     {
    //         Gpa = 94.54,
    //         Tatc = 150,
    //         Tacc = 150,
    //         Sac = 0,
    //         Semesters = semesters
    //     };
    // }
}
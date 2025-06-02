namespace sislte.Models;

public class StudentSemester
{
    public int Id { get; set; }
    public int StudentCourseProgramId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public StudentCourseProgram StudentCourseProgram { get; set; }
}
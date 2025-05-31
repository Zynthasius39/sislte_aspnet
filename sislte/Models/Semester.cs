using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sislte.Models;

public class Semester
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    [Required]
    public DateOnly EndDate { get; set; }

    public int? Spa { get; set; }
    [Required]
    public List<Course> Courses { get; set; }

    private static int _counter = 0;

    public static Semester GetExampleSemester()
    {
        _counter += 4;
        var courses = Course.GetExampleCourses().Slice(_counter - 4, 4);
        var spa = courses.Sum(course => course.Ects);
        return new Semester()
        {
            StartDate = new DateOnly(2022, 9, 15),
            EndDate = new DateOnly(2023, 6, 28),
            Spa = spa,
            Courses = courses
        };
    }
}
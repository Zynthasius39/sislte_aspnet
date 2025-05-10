namespace sislte.Models;

public class Semester
{
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
    public int Spa { get; set; } = 0;
    public required List<Course> Courses { get; set; }

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
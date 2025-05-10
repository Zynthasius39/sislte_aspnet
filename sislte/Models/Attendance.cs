namespace sislte.Models;

public class Attendance
{
    public required Course Course { get; set; }
    public required DateOnly Date { get; set; }
    public required Presence Presence { get; set; }

    public string GetPresenceAsString()
    {
        return Presence switch
        {
            Presence.Present => "Present",
            Presence.Absent => "Absent",
            Presence.Late => "Late"
        };
    }

    public string GetBootstrapClass()
    {
        return Presence switch
        {
            Presence.Present => "bg-success",
            Presence.Absent => "bg-danger",
            Presence.Late => "bg-warning"
        };
    }

    public static List<Attendance> GetExampleAttendances(int count = 8)
    {
        var values = Enum.GetValues(typeof(Presence));
        var courses = Course.GetExampleCourses();
        var random = new Random();
        var attendances = new List<Attendance>();
        for (var i = 0; i < count; i++)
            attendances.Add(
                new Attendance()
                {
                    Course = courses[random.Next(courses.Count)],
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Presence = (Presence)values.GetValue(random.Next(0, values.Length)),
                }
            );
        return attendances;
    }
}

public enum Presence
{
    Present,
    Absent,
    Late
}
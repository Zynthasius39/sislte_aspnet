using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sislte.Models;

public class AttendanceEntry
{
    public int Id { get; set; }
    public int GradeId { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    public Presence Presence { get; set; }
    public Grade Grade { get; set; }

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

    // public static List<AttendanceEntry> GetExampleAttendances(int count = 8)
    // {
    //     var values = Enum.GetValues(typeof(Presence));
    //     var courses = Course.GetExampleCourses();
    //     var random = new Random();
    //     var attendances = new List<AttendanceEntry>();
    //     for (var i = 0; i < count; i++)
    //         attendances.Add(
    //             new AttendanceEntry()
    //             {
    //                 Course = courses[random.Next(courses.Count)],
    //                 Date = DateOnly.FromDateTime(DateTime.Now),
    //                 Presence = (Presence)values.GetValue(random.Next(0, values.Length)),
    //             }
    //         );
    //     return attendances;
    // }
}

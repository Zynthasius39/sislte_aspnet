using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace sislte.Models;

public class DetailedStudent
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    [MaxLength(50)] public string FullName { get; set; }
    public string Phone { get; set; }
    public string EmergencyPhone { get; set; }
    public string Location { get; set; }
    public string Education { get; set; }
    public string? Notes { get; set; }
    public int EarnedCredits { get; set; }
    public double Gpa { get; set; }
    public double Loans { get; set; }
    public Advisor Advisor { get; set; }
    public Scholarship? Scholarship { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly EntranceDate { get; set; }
    public DateOnly GraduateDate { get; set; }
    public Transcript Transcript { get; set; }
    public ICollection<Club> JoinedClubs { get; set; } = new List<Club>();
    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public Student Student { get; set; } = null!;
}
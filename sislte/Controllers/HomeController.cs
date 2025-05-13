using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sislte.Models;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Index";
        ViewBag.FullName = "Sekiro";
        ViewBag.GPA = 3.74;
        ViewBag.Courses = 30;
        ViewBag.Friends = 68;
        ViewBag.AvatarURL = "/assets/img/studphoto.jpg";
        ViewBag.DetailedInfo = new List<DetailedInfo>();
        ViewBag.DetailedInfo = new List<DetailedInfo>
        {
            new DetailedInfo("Full Name", "Jane Doe"),
            new DetailedInfo("Student ID", "202312345"),
            new DetailedInfo("Email", "jane.doe@example.edu"),
            new DetailedInfo("Phone Number", "+1 (555) 123-4567"),
            new DetailedInfo("Date of Birth", "2003-05-12"),
            new DetailedInfo("Enrollment Status", "Active"),
            new DetailedInfo("Program", "Bachelor of Science in Computer Science"),
            new DetailedInfo("Year of Study", "3rd Year"),
            new DetailedInfo("GPA", "3.75"),
            new DetailedInfo("Credits Earned", "90"),
            new DetailedInfo("Expected Graduation Date", "May 2026"),
            new DetailedInfo("Advisor", "Dr. Alan Smith"),
            new DetailedInfo("Loans", "Yes"),
            new DetailedInfo("Scholarship Status", "Awarded (Merit-Based)"),
            new DetailedInfo("Tuition Balance", "$1,500"),
            new DetailedInfo("Courses Enrolled",
                "CS301: Algorithms, CS320: Web Development, MATH210: Linear Algebra, ENG205: Technical Writing"),
            new DetailedInfo("Attendance Rate", "92%"),
            new DetailedInfo("Library Fines", "$0"),
            new DetailedInfo("Internship Placement", "In Progress"),
            new DetailedInfo("Clubs Joined", "Women in Tech, Robotics Club"),
            new DetailedInfo("Emergency Contact", "Mary Doe, +1 (555) 987-6543")
        };
        ViewBag.About = new About()
        {
            Education = "B.S. in Information Technologies from Baku Engineering University",
            Location = "Sumgait, Azerbaijan",
            Skills = "Cisco CCNA, Linux, Windows, Git",
            Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam fermentum enim neque."
        };
        return View();
    }

    [HttpGet]
    public IActionResult Contact()
    {
        ViewData["ActivePage"] = "Contact";
        ViewBag.ContactEmail = "support@beu.edu.az";
        ViewBag.ContactPhone = "+994 12 1212242";
        ViewBag.ContactAddress = "Khirdalan, Baku Engineering University";
        return View();
    }

    [HttpPost]
    public IActionResult Contact(ContactForm model)
    {
        return Redirect("https://alakx.com");
    }
}

internal record About
{
    public required string Education { get; set; }
    public required string Skills { get; set; }
    public required string Location { get; set; }
    public required string Notes { get; set; }
}
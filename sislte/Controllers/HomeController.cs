using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Index";
        ViewBag.FullName = "Sekiro";
        ViewBag.GPA = 3.74;
        ViewBag.Courses = 30;
        ViewBag.Friends = 68;
        ViewBag.AvatarURL = "assets/img/studphoto.jpg";
        ViewBag.DetailedInfo = new List<DetailedInfo>();
        ViewBag.DetailedInfo.Add(new DetailedInfo()
        {
            Field = "E-Mail",
            Value = "sekiro@std.beu.edu.az"
        });
        ViewBag.About = new About()
        {
            Education = "B.S. in Information Technologies from Baku Engineering University",
            Location = "Sumgait, Azerbaijan",
            Skills = "Cisco CCNA, Linux, Windows, Git",
            Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam fermentum enim neque."
        };
        return View();
    }
    
}

internal record DetailedInfo
{
    public required string Field { get; set; }
    public required string Value { get; set; }
}

internal record About
{
    public required string Education { get; set; }
    public required string Skills { get; set; }
    public required string Location { get; set; }
    public required string Notes { get; set; }
}
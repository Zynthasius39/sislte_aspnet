using Microsoft.AspNetCore.Mvc;

[Route("{pageName}")]
public class PageController : Controller
{
    [HttpGet]
    public IActionResult GetPage(string pageName)
    {
        if (pageName == "login") return Login();
        if (pageName == "register") return Register();
        return Index();
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Index";
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Announces()
    {
        ViewData["ActivePage"] = "Announces";
        return View();
    }

    public IActionResult Attendance()
    {
        ViewData["ActivePage"] = "Attendance";
        return View();
    }

    public IActionResult Departments()
    {
        ViewData["ActivePage"] = "Departments";
        return View();
    }

    public IActionResult Courses()
    {
        ViewData["ActivePage"] = "Courses";
        return View();
    }

    public IActionResult Grades()
    {
        ViewData["ActivePage"] = "Grades";
        return View();
    }

    public IActionResult Transcript()
    {
        ViewData["ActivePage"] = "Transcript";
        return View();
    }
}
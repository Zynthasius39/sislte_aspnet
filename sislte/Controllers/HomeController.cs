using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Index";
        return View();
    }
    
}
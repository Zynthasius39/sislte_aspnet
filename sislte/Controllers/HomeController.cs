using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sislte.Models;
using sislte.Repository;
using sislte.ViewModels;

public class HomeController : Controller
{
    private readonly IStudentRepository _studentRepository;
    public HomeController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Index";
        return View(_studentRepository.Get());
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
    public IActionResult Contact(ContactDto model)
    {
        return Redirect("https://alakx.com");
    }
    
    [HttpGet]
    public IActionResult EditAboutMe()
    {
        return View(_studentRepository.GetEditAboutMe());
    }
    
    [HttpPost]
    public IActionResult EditAboutMe(Student student)
    {
        StudentRepository.StudentExample.FullName = student.FullName;
        StudentRepository.StudentExample.Location = student.Location;
        StudentRepository.StudentExample.Education = student.FullName;
        StudentRepository.StudentExample.Notes = student.Notes;
        StudentRepository.StudentExample.Skills = student.Skills;
        return RedirectToAction("Index");
    }
}

internal record About
{
    public required string Education { get; set; }
    public required string Skills { get; set; }
    public required string Location { get; set; }
    public required string Notes { get; set; }
}
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sislte.DTOs;
using sislte.Models;
using sislte.Repository;
using sislte.ViewModels;

[Authorize]
public class HomeController(IStudentRepository studentRepository) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Index";
        var student = studentRepository.GetByEmail(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
        if (student == null)
            return Unauthorized();
        Console.WriteLine(student);
        if (student.DetailedStudent == null)
            return Ok("Admin");

        var vm = new StudentHomeViewModel
        {
            DetailedStudent = student.DetailedStudent,
        };
        return View(vm);
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
    public IActionResult Contact(ContactDto contactDto)
    {
        return Redirect("https://alakx.com");
    }
    
    [HttpGet]
    public IActionResult EditAboutMe()
    {
        var student = studentRepository.GetByEmail(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
        if (student == null)
            return Unauthorized();

        var vm = new EditAboutMeViewModel
        {
            DetailedStudent = student.DetailedStudent,
        };
        return View(vm);
    }
    
    [HttpPost]
    public IActionResult EditAboutMe(EditAboutMeDto editAboutMeDto)
    {
        var student = studentRepository.GetByEmail(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
        
        if (student == null)
            return Unauthorized();
        if (student.DetailedStudent == null)
            return Forbid();
        
        student.DetailedStudent.FullName = editAboutMeDto.FullName;
        student.DetailedStudent.Location = editAboutMeDto.Location;
        student.DetailedStudent.Education = editAboutMeDto.Education;
        student.DetailedStudent.Notes = editAboutMeDto.Notes;
        
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
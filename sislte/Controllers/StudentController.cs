using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sislte.Core;
using sislte.DTOs;
using sislte.Models;
using sislte.Repositories;
using sislte.Services;
using sislte.ViewModels;

namespace sislte.Controllers;

[Authorize]
[ServiceFilter(typeof(AuthorizedFilter))]
public class StudentController(
    IStudentRepository studentRepository,
    IAnnouncesRepository announcesRepository,
    ICourseRepository courseRepository,
    ICourseProgramRepository courseProgramRepository,
    IGradeRepository gradeRepository,
    IAuthService authService,
    IWebHostEnvironment webHostEnvironment,
    SisContext context
) : Controller
{
    public async Task<IActionResult> Announces()
    {
        ViewData["ActivePage"] = "Announces";
        return View(await announcesRepository.GetAll());
    }

    // public IActionResult Attendance()
    // {
    //     ViewData["ActivePage"] = "Attendance";
    //     ViewBag.SemesterNo = 1;
    //     ViewBag.FullName = "Sekiro Wolf";
    //     ViewBag.Program = "Internet Technologies";
    //     ViewBag.Attendances = sislte.Models.AttendanceEntry.GetExampleAttendances();
    //     return View();
    // }
    
    public async Task<IActionResult> Programs()
    {
        ViewData["ActivePage"] = "Programs";
        return View(await courseProgramRepository.GetAll());
    }
    
    public async Task<IActionResult> Courses()
    {
        ViewData["ActivePage"] = "Courses";
        return View(await courseRepository.GetAll());
    }
    
    public async Task<IActionResult> Grades()
    {
        ViewData["ActivePage"] = "Grades";
        return View(await gradeRepository.GetAll());
    }
    
    // public IActionResult Transcript()
    // {
    //     ViewData["ActivePage"] = "Transcript";
    //     ViewBag.FullName = "Sekiro Wolf";
    //     ViewBag.Email = "sekiro@std.beu.edu.az";
    //     ViewBag.Phone = "+994(55) 555-55-55";
    //     ViewBag.Program = "Information Technologies";
    //     ViewBag.StudentId = 220106000;
    //     ViewBag.Transcript = sislte.Models.Transcript.GetExampleTranscript();
    //     return View();
    // }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewData["ActivePage"] = "Index";
        var student = await authService.GetCurrentStudentAsync();

        if (student?.DetailedStudent != null)
            return View(new StudentHomeViewModel
            {
                DetailedStudent = student.DetailedStudent,
            });

        return Unauthorized();
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

    // TODO: Contact Page
    [HttpPost]
    public IActionResult Contact(ContactDto contactDto)
    {
        return Redirect("https://alakx.com");
    }


    [HttpGet]
    public async Task<IActionResult> EditAboutMe()
    {
        var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        Console.WriteLine(email + " | " + role);
        if (string.IsNullOrEmpty(email) || role == nameof(Role.PreservedStudent))
            return Unauthorized();

        var student = await studentRepository.GetByEmailAsync(
            email,
            query => query.Include(s => s.DetailedStudent)
        );

        if (student?.DetailedStudent == null)
            return Unauthorized();

        var vm = new EditAboutMeDto
        {
            FullName = student.DetailedStudent.FullName,
            Education = student.DetailedStudent.Education,
            Location = student.DetailedStudent.Location,
            Notes = student.DetailedStudent.Notes ?? "",
        };
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> EditAboutMe([FromForm] EditAboutMeDto editAboutMeDto)
    {
        var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(email))
            return Unauthorized();

        var student = await studentRepository.GetByEmailAsync(
            email,
            query => query.Include(s => s.DetailedStudent)
        );

        if (student == null)
            return Unauthorized();
        if (student.DetailedStudent == null)
            return Forbid();

        Console.WriteLine(editAboutMeDto.Avatar?.Length.ToString() ?? "NULL AVATAR");
        if (editAboutMeDto.Avatar == null || editAboutMeDto.Avatar.Length == 0)
            return BadRequest();

        if (editAboutMeDto.Avatar.Length > 2 * 1024 * 1024)
            ViewBag.Errors = new List<string>{ "File too large" };

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var extension = Path.GetExtension(editAboutMeDto.Avatar.FileName).ToLowerInvariant();

        if (!allowedExtensions.Contains(extension))
            ViewBag.Errors = new List<string>{ "File format not supported" };

        var fileName = Guid.NewGuid() + extension;
        var filePath = Path.Combine(webHostEnvironment.WebRootPath, "avatars", fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await editAboutMeDto.Avatar.CopyToAsync(stream);
        }

        student.DetailedStudent.FullName = editAboutMeDto.FullName;
        student.DetailedStudent.Location = editAboutMeDto.Location;
        student.DetailedStudent.Education = editAboutMeDto.Education;
        student.DetailedStudent.Notes = editAboutMeDto.Notes;
        student.AvatarURL = filePath;
        await studentRepository.UpdateAsync(student);

        return RedirectToAction("Index");
    }

    public static string GetMarkForSum(int sum)
    {
        return sum switch
        {
            >= 99 => "A+",
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            >= 50 => "E",
            >= 30 => "F",
            _ => ""
        };
    }

    public static string GetColorForMark(string mark)
    {
        return mark switch
        {
            "A+" => "#18a06e", // Deep Green
            "A" => "#4caf50", // Green
            "B" => "#8bc34a", // Light Green
            "C" => "#cddc39", // Lime
            "D" => "#ffeb3b", // Yellow
            "E" => "#ff9800", // Orange
            "F" => "#f44336", // Red
            _ => "#9e9e9e" // Gray for unknown
        };
    }
}
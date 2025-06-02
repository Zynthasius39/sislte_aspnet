using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using sislte.DTOs;
using sislte.Models;
using sislte.Repositories;
using sislte.Services;
using sislte.ViewModels;
using sislte.ViewModels.Layout;

namespace sislte.Controllers;

public class StudentController(IStudentRepository studentRepository, IAuthService authService) : Controller
{
    //
    // public IActionResult Announces()
    // {
    //     ViewData["ActivePage"] = "Announces";
    //     ViewBag.Announces = new List<Announce>();
    //     ViewBag.Announces.Add(
    //         new Announce()
    //         {
    //             Title = "Tələbələrin nəzərinə: 8000-dən çox beynəlxalq təlimə ödənişsiz qoşulmaq fürsətini qaçırmayın!",
    //             Message =
    //                 "İqtisadiyyat Nazirliyinin tabeliyində Dördüncü Sənaye İnqilabının Təhlili və Koordinasiya Mərkəzi (4SİM), Elm və Təhsil Nazirliyinin tabeliyində Təhsilin İnkişafı Fondu və ABŞ-nin “Coursera” şirkətinin birgə əməkdaşlığı ilə “4Sİ Akadeniyası-Milli Proqram”a qeydiyyat davam edir. Proqram 1 il ərzində on minlərlə istifadəçinin dünyanın ən böyük onlayn tədris platforması olan “Coursera”da təlimlərdən ödənişsiz faydalanmaq üçün əvəzolunmaz fürsətdir. https://form.4sim.gov.az/ linkinə daxil olub qeydiyyatdan keçərək bu imkandan yararlana bilərsiniz.",
    //             Date = DateOnly.FromDateTime(DateTime.Now)
    //         }
    //     );
    //     return View();
    // }
    //
    // public IActionResult Attendance()
    // {
    //     ViewData["ActivePage"] = "Attendance";
    //     ViewBag.SemesterNo = 1;
    //     ViewBag.FullName = "Sekiro Wolf";
    //     ViewBag.Program = "Internet Technologies";
    //     ViewBag.Attendances = sislte.Models.AttendanceEntry.GetExampleAttendances();
    //     return View();
    // }
    //
    // public IActionResult Programs()
    // {
    //     ViewData["ActivePage"] = "Programs";
    //     ViewBag.Programs = StudentCourseProgram.GetExamplePrograms();
    //     return View();
    // }
    //
    // public IActionResult Courses()
    // {
    //     ViewData["ActivePage"] = "Courses";
    //     ViewBag.Courses = Course.GetExampleCourses().Slice(8, 5);
    //     return View();
    // }
    //
    // public IActionResult Grades()
    // {
    //     ViewData["ActivePage"] = "Grades";
    //     ViewBag.Grades = Grade.GetExampleGrades();
    //     return View();
    // }
    //
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
        var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(email))
        {
            return Unauthorized();
        }

        var student = await studentRepository.GetByEmailAsync(email, true);

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
            Notes = student.DetailedStudent.Notes,
        };
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> EditAboutMe(EditAboutMeDto editAboutMeDto)
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

        student.DetailedStudent.FullName = editAboutMeDto.FullName;
        student.DetailedStudent.Location = editAboutMeDto.Location;
        student.DetailedStudent.Education = editAboutMeDto.Education;
        student.DetailedStudent.Notes = editAboutMeDto.Notes;
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
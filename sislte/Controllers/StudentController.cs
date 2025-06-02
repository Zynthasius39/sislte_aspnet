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
    IAuthService authService,
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
    
    // public IActionResult Courses()
    // {
    //     ViewData["ActivePage"] = "Courses";
    //     ViewBag.Courses = Course.GetExampleCourses().Slice(8, 5);
    //     return View();
    // }
    //
    public async Task<IActionResult> Grades()
    {
        ViewData["ActivePage"] = "Grades";

        var courses = new List<Course>
        {
            // AE Courses
            new Course { Code = "IT 113", Name = "Information management", Theory = 1, Ects = 3 },
            new Course { Code = "IT 115", Name = "Information technologies", Theory = 1, Ects = 3 },
            new Course { Code = "IT 188", Name = "Computer-aided design", Theory = 2, Ects = 7 },
            new Course { Code = "IT 205", Name = "Object oriented programming", Theory = 2, Ects = 7 },
            new Course { Code = "IT 252", Name = "Basics of programming- 2", Theory = 2, Ects = 5 },
            new Course { Code = "IT 338", Name = "Internet Technologies", Theory = 2, Ects = 6 },
            new Course { Code = "IT 383", Name = "Computer modeling", Theory = 2, Ects = 7 },
            new Course { Code = "IT 385", Name = "Management in information systems", Theory = 2, Ects = 7 },
            new Course { Code = "IT 386", Name = "Web programming", Theory = 2, Ects = 6 },
            new Course { Code = "IT 387", Name = "Introduction to multi-platform programming", Theory = 2, Ects = 7 },
            new Course { Code = "IT 388", Name = "Modern programming languages- 2", Theory = 2, Ects = 7 },
            new Course { Code = "IT 390", Name = "Mobile application design", Theory = 2, Ects = 7 },
            new Course { Code = "IT 437", Name = "Machine Learning", Theory = 2, Ects = 6 },
            new Course { Code = "IT 451", Name = "Data Mining and Storing", Theory = 2, Ects = 6 },
            new Course { Code = "IT 485", Name = "Database programming", Theory = 2, Ects = 6 },
            new Course { Code = "IT 487", Name = "Data analytics and information management", Theory = 2, Ects = 6 },
            new Course { Code = "MINF 273", Name = "Mathematical programming", Theory = 2, Ects = 7 },

            // NAE Courses
            new Course
            {
                Code = "BA 108", Name = "Principles of Entrepreneurship and Introduction to Business", Theory = 1,
                Ects = 3
            },
            new Course { Code = "BA 111", Name = "Fundamentals of Management", Theory = 1, Ects = 9 },
            new Course { Code = "ECON 163", Name = "Engineering Economics", Theory = 1, Ects = 9 },
            new Course
            {
                Code = "ENG 010", Name = "English for business and academic communication (reading and writing)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "ENG 020", Name = "English for business and academic communication (listening and speaking)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "ENG 030", Name = "English for business and academic communication (for academic purposes)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "GER 010", Name = "German business and academic communication (reading and writing)", Theory = 0,
                Ects = 5
            },
            new Course
            {
                Code = "GER 020", Name = "German for business and academic communication (listening and speaking)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "GER 030", Name = "German for business and academic communication (for academic purposes)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "LAW 110", Name = "Constitution of Republic of Azerbaijan and Fundamentals of Law", Theory = 1,
                Ects = 3
            },
            new Course { Code = "MATH 285", Name = "Numerical analysis", Theory = 2, Ects = 5 },
            new Course { Code = "MINF 167", Name = "Logic", Theory = 1, Ects = 3 },
            new Course { Code = "PA 139", Name = "Politology", Theory = 1, Ects = 3 },
            new Course { Code = "PHIL 159", Name = "Philosophy", Theory = 1, Ects = 3 },
            new Course { Code = "SOC 110", Name = "Sociology", Theory = 1, Ects = 3 },
            new Course { Code = "SOC 150", Name = "Introduction to Multiculturalism", Theory = 1, Ects = 3 },
            new Course { Code = "SOC 180", Name = "Ethics and aesthetics", Theory = 1, Ects = 3 },
        };

        courses.ForEach(c => context.Courses.Add(c));
        await context.SaveChangesAsync();
        
        // var courseProgram = new CourseProgram {
        //     Name = "MAIN",
        //     Code = "M0",
        //     Lang = "EN",
        //     Courses = courses
        // };
        // context.CoursePrograms.Add(courseProgram);
        // await context.SaveChangesAsync();
        
        return Ok();
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
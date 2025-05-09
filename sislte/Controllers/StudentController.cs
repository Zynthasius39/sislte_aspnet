using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sislte;
using sislte.Models;

public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Login login)
    {
        if (login.StudentID == "220106000" &&
            login.Password == "96CAE35CE8A9B0244178BF28E4966C2CE1B8385723A96A6B838858CDD6CA0A1E")
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(login.StudentID)),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var creds = new SigningCredentials(JwtConfig.Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "SisLte",
                audience: "SisLte",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        return Unauthorized();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Register register)
    {
        // Create new entity and get StudentID to be used in JWT generation.
        // var claims = new[]
        // {
        //     new Claim(ClaimTypes.NameIdentifier, Convert.ToString(register.StudentID)),
        //     new Claim(ClaimTypes.Role, "Admin")
        // };

        // var creds = new SigningCredentials(JwtConfig.Key, SecurityAlgorithms.HmacSha256);

        // var token = new JwtSecurityToken(
        //     issuer: "SisLte",
        //     audience: "SisLte",
        //     claims: claims,
        //     expires: DateTime.Now.AddHours(1),
        //     signingCredentials: creds
        // );

        var errors = ModelState
            .Where(ms => ms.Value.Errors.Count > 0)
            .SelectMany(ms => ms.Value.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        return Ok(new
        {
            email = register.Email,
            password = register.Password,
            confirmPassword = register.ConfirmPassword,
            errors = String.Join(", ", errors),
            ok = ModelState.IsValid
        });
    }

    public IActionResult Announces()
    {
        ViewData["ActivePage"] = "Announces";
        ViewBag.Announces = new List<Announce>();
        ViewBag.Announces.Add(
            new Announce()
            {
                Title = "Tələbələrin nəzərinə: 8000-dən çox beynəlxalq təlimə ödənişsiz qoşulmaq fürsətini qaçırmayın!",
                Message = "İqtisadiyyat Nazirliyinin tabeliyində Dördüncü Sənaye İnqilabının Təhlili və Koordinasiya Mərkəzi (4SİM), Elm və Təhsil Nazirliyinin tabeliyində Təhsilin İnkişafı Fondu və ABŞ-nin “Coursera” şirkətinin birgə əməkdaşlığı ilə “4Sİ Akadeniyası-Milli Proqram”a qeydiyyat davam edir. Proqram 1 il ərzində on minlərlə istifadəçinin dünyanın ən böyük onlayn tədris platforması olan “Coursera”da təlimlərdən ödənişsiz faydalanmaq üçün əvəzolunmaz fürsətdir. https://form.4sim.gov.az/ linkinə daxil olub qeydiyyatdan keçərək bu imkandan yararlana bilərsiniz.",
                Date = DateOnly.FromDateTime(DateTime.Now)
            }
        );
        return View();
    }

    public IActionResult Attendance()
    {
        ViewData["ActivePage"] = "Attendance";
        return View();
    }

    public IActionResult Programs()
    {
        ViewData["ActivePage"] = "Programs";
        ViewBag.Programs = new List<CProgram>();
        ViewBag.Programs.Add(new CProgram()
        {
            Code = "DEP_IT_PROG",
            Name = "Information technologies and programming",
            Prefix = "ICT, IT, ITS, MIS, SAI, IT, İİS"
        });
        return View();
    }

    public IActionResult Courses()
    {
        ViewData["ActivePage"] = "Courses";
        ViewBag.Courses = new List<Course>();
        ViewBag.Courses.Add(new Course()
        {
            Code = "IT113",
            Name = "Information management",
            Type = "def",
            Ects = 3
        });
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

internal record Announce
{
    public required string Title { get; set; }
    public required string Message { get; set; }
    public required DateOnly Date { get; set; }
}

internal record CProgram
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Prefix { get; set; }
}

internal record Course
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required int Ects { get; set; }
}

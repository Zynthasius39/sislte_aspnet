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
        if (login.StudentID == "220106000" && login.Password == "96CAE35CE8A9B0244178BF28E4966C2CE1B8385723A96A6B838858CDD6CA0A1E")
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

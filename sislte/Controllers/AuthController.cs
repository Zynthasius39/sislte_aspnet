using Microsoft.AspNetCore.Mvc;
using sislte.DTOs;
using sislte.Exceptions;
using sislte.Services;

namespace sislte.Controllers;

public class AuthController(IAuthService authService) : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.errors = ModelState
                .Where(ms => ms.Value.Errors.Count > 0)
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return View();
        }

        string token;

        try
        {
            token = await authService.Login(loginDto);
        }
        catch (StudentException ex)
        {
            ViewBag.errors = new List<string> { ex.Message };
            return View();
        }

        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        });

        return RedirectToAction("Index", "Student");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Reset()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Reset(ResetDto resetDto)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.errors = ModelState
                .Where(ms => ms.Value.Errors.Count > 0)
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return View();
        }

        string token;

        try
        {
            token = await authService.Register(registerDto);
        }
        catch (StudentException ex)
        {
            ViewBag.errors = new List<string> { ex.Message };
            return View();
        }

        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        });

        return RedirectToAction("Index", "Student");
    }
}
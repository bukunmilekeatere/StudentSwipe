using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using StudentSwipe.Models;
using System.Diagnostics.CodeAnalysis;
public class AuthenticationController : Controller
{
    [HttpGet("Register")]
    public IActionResult Register()
    {
        return View("~/Views/Home/Register.cshtml");
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View("~/Views/Home/Login.cshtml");
    }


    private readonly ApplicationDbContext _context;
	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;

	public AuthenticationController(
		ApplicationDbContext context,
		UserManager<IdentityUser> userManager,
		SignInManager<IdentityUser> signInManager)
	{
		_context = context;
		_userManager = userManager;
		_signInManager = signInManager;
	}

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromForm]RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View("~/Views/Home/Login.cshtml");

        var emailDomain = model.Email.Split('@').Last().ToLower();

        var isAllowed = _context.SchoolDomains
            .Any(d => emailDomain.EndsWith(d.Domain.ToLower()));

        if (!isAllowed)
        {
            ModelState.AddModelError("Email", "Please use a valid school email address.");
            return View("~/Views/Home/Login.cshtml");
        }

        var user = new IdentityUser { UserName = model.Email, Email = model.Email};
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View("~/Views/Home/Login.cshtml", model);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromForm] LoginModel model)
    {

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        if (!result.Succeeded)
        {
            TempData["LoginError"] = "Invalid login attempt.";
            return RedirectToAction("Login");
        }

        return RedirectToAction("Index", "Home"); // Show feed
    }


    [HttpPost("Logout")]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();
		return Ok("Logout successful"); 
	}

}
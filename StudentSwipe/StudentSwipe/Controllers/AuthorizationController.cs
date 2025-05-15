using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using StudentSwipe.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("Authorization/Login")]
public class AuthenticationController : Controller
{

	public IActionResult Index()
	{
		return View("~/Views/Home/Index.cshtml");
	}

	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;


	public AuthenticationController(
		UserManager<IdentityUser> userManager,
		SignInManager<IdentityUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
	{
		var user = new IdentityUser { UserName = model.Email, Email = model.Email };
		var result = await _userManager.CreateAsync(user, model.Password);

		if (!result.Succeeded)
			return BadRequest(result.Errors);
		return Ok("Registered successfully");
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromForm] LoginModel model)
	{
		var user = await _userManager.FindByEmailAsync(model.Email);
		if (user == null)
		{
			Console.WriteLine("User not found!");
			TempData["LoginError"] = "Invalid login attempt.";
			return RedirectToAction("Login");
		}

		var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
		if (!result.Succeeded)
		{
			TempData["LoginError"] = "Invalid login attempt.";
			return RedirectToAction("Index");
		}
		TempData["LoginSuccess"] = "You have successfully logged in!";
		return RedirectToAction("Index");
	}

	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();
		return Ok("Logout successful"); 
	}

}
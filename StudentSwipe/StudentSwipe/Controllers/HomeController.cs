using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentSwipe.Models;

namespace StudentSwipe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return RedirectToAction("LogIn");
        }

        public IActionResult LogIn()
        {
            return View("~/Views/Home/Login.cshtml");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

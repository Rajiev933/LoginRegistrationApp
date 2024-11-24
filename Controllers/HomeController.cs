using LoginRegistrationApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginRegistrationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Login(Register users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        TempData["SuccessMessage"] = "Registration successful please login!";
        //        return RedirectToAction("Login"); 
        //    }
        //    return View("Register", users); 
        //}
        public IActionResult Home()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Home(Login user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        TempData["SuccessMessage"] = "Login successful!";
        //        return RedirectToAction("Home");
        //    }
        //    return View("Login", user);
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

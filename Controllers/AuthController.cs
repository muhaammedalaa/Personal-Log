using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;

namespace PersonalBlog.Controllers
{
    public class AuthController : Controller
    {
       private const string USERNAME = "admin";
         private const string PASSWORD = "password123";
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (login.Username == USERNAME && login.Password == PASSWORD)
                {
                    HttpContext.Session.SetString("IsAuthenticated", "true");
                    // In a real application, set up authentication cookie or token here
                    return RedirectToAction("Dashboard", "Admin");
                }
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            return View(login);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAuthenticated");
            // In a real application, clear authentication cookie or token here
            return RedirectToAction("Login");
        }
    }
}

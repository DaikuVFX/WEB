using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WEB.Controllers
{
    public class UserController : Controller
    {
        // GET: /User (profil po přihlášení)
        [Authorize]
        public IActionResult Index()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            ViewBag.Username = username;
            return View();
        }

        // GET: /User/Register
        public IActionResult Register()
        {
            return RedirectToAction("Register", "Account");
        }

        // GET: /User/Login
        public IActionResult Login()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
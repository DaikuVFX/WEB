using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEB.Data;
using WEB.Models;

namespace WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = _db.Users.FirstOrDefault(u => u.Username == username);
            ViewBag.Username = username;
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(string displayName)
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = _db.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.DisplayName = displayName;
                await _db.SaveChangesAsync();
                ViewBag.Success = "Změny uloženy!";
            }
            ViewBag.Username = username;
            return View(user);
        }

        public IActionResult Register()
        {
            return RedirectToAction("Register", "Account");
        }

        public IActionResult Login()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
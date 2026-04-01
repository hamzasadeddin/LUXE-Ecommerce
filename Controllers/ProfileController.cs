using Microsoft.AspNetCore.Mvc;
using LuxeEcommerce.Models;

namespace LuxeEcommerce.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
                return RedirectToAction("Login", "Account");

            var user = new User
            {
                FullName = HttpContext.Session.GetString("UserName"),
                Email = HttpContext.Session.GetString("UserEmail"),
                AvatarUrl = HttpContext.Session.GetString("UserAvatar"),
                MemberSince = HttpContext.Session.GetString("UserSince"),
                Phone = "+1 (555) 000-0000"
            };
            return View(user);
        }
    }
}
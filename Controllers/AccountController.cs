using Microsoft.AspNetCore.Mvc;
using LuxeEcommerce.Models.MockData;
using System.Linq;

namespace LuxeEcommerce.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = "")
        {
            if (HttpContext.Session.GetString("UserName") != null)
                return RedirectToAction("Index", "Home");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password, string returnUrl = "")
        {
            var user = MockDataStore.Users.FirstOrDefault(u =>
                u.Email.ToLower() == email.ToLower() && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.FullName);
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserAvatar", user.AvatarUrl ?? "");
                HttpContext.Session.SetString("UserSince", user.MemberSince ?? "");
                HttpContext.Session.SetInt32("UserId", user.Id);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password. Try: hamza@luxe.com / password123";
            return View();
        }

        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("UserName") != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string fullName, string email, string password, string phone)
        {
            if (MockDataStore.Users.Any(u => u.Email.ToLower() == email.ToLower()))
            {
                ViewBag.Error = "An account with this email already exists.";
                return View();
            }

            var newUser = new Models.User
            {
                Id = MockDataStore.Users.Count + 1,
                FullName = fullName,
                Email = email,
                Password = password,
                Phone = phone,
                AvatarUrl = $"https://i.pravatar.cc/150?img={MockDataStore.Users.Count + 10}",
                MemberSince = System.DateTime.Now.ToString("MMMM yyyy")
            };

            MockDataStore.Users.Add(newUser);
            HttpContext.Session.SetString("UserName", newUser.FullName);
            HttpContext.Session.SetString("UserEmail", newUser.Email);
            HttpContext.Session.SetString("UserAvatar", newUser.AvatarUrl);
            HttpContext.Session.SetString("UserSince", newUser.MemberSince);
            HttpContext.Session.SetInt32("UserId", newUser.Id);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
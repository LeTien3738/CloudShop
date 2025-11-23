using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly PhoneStoreContext _context;
        private const string UserSessionKey = "UserId";
        private const string UserNameKey = "UserName";

        public AccountController(PhoneStoreContext context)
        {
            _context = context;
        }

        // GET: Account/Login
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnUrl = null)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password && !u.IsAdmin);

            if (user != null)
            {
                HttpContext.Session.SetInt32(UserSessionKey, user.Id);
                HttpContext.Session.SetString(UserNameKey, user.FullName);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng!";
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(User user, string confirmPassword)
        {
            if (user.Password != confirmPassword)
            {
                ViewBag.Error = "Mật khẩu xác nhận không khớp!";
                return View(user);
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null)
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại!";
                return View(user);
            }

            user.IsAdmin = false;
            user.CreatedAt = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Đăng ký thành công! Vui lòng đăng nhập.";
            return RedirectToAction("Login");
        }

        // GET: Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(UserSessionKey);
            HttpContext.Session.Remove(UserNameKey);
            return RedirectToAction("Index", "Home");
        }
    }
}

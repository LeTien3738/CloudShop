using Microsoft.AspNetCore.Mvc;
using PhoneStore.Data;
using PhoneStore.Models;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly PhoneStoreContext _context;
        private const string AdminSessionKey = "IsAdmin";

        public AdminController(PhoneStoreContext context)
        {
            _context = context;
        }

        // GET: Admin/Login
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString(AdminSessionKey) == "true")
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Đơn giản: admin/admin123
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session.SetString(AdminSessionKey, "true");
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return View();
        }

        // GET: Admin/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(AdminSessionKey);
            return RedirectToAction("Login");
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var totalProducts = await _context.Phones.CountAsync();
            var totalStock = await _context.Phones.SumAsync(p => p.Stock);
            var totalUsers = await _context.Users.CountAsync(u => !u.IsAdmin);
            var totalOrders = await _context.Orders.CountAsync();

            ViewBag.TotalProducts = totalProducts;
            ViewBag.TotalStock = totalStock;
            ViewBag.TotalUsers = totalUsers;
            ViewBag.TotalOrders = totalOrders;

            return View();
        }

        // GET: Admin/Users
        public async Task<IActionResult> Users()
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var users = await _context.Users.OrderByDescending(u => u.CreatedAt).ToListAsync();
            return View(users);
        }

        // POST: Admin/DeleteUser/5
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var user = await _context.Users.FindAsync(id);
            if (user != null && !user.IsAdmin)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Xóa người dùng thành công!";
            }

            return RedirectToAction("Users");
        }

        // GET: Admin/Products
        public async Task<IActionResult> Products()
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var phones = await _context.Phones.ToListAsync();
            return View(phones);
        }

        // GET: Admin/CreateProduct
        public IActionResult CreateProduct()
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        // POST: Admin/CreateProduct
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Phone phone, IFormFile? imageFile)
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            // Upload ảnh nếu có
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                
                // Tạo thư mục nếu chưa có
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"));
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                
                phone.ImageUrl = "/images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Phones.Add(phone);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Products");
            }

            return View(phone);
        }

        // GET: Admin/EditProduct/5
        public async Task<IActionResult> EditProduct(int id)
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Admin/EditProduct/5
        [HttpPost]
        public async Task<IActionResult> EditProduct(Phone phone, IFormFile? imageFile)
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            // Upload ảnh mới nếu có
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"));
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                
                phone.ImageUrl = "/images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Phones.Update(phone);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("Products");
            }

            return View(phone);
        }

        // POST: Admin/DeleteProduct/5
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var phone = await _context.Phones.FindAsync(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Xóa sản phẩm thành công!";
            }

            return RedirectToAction("Products");
        }

        // GET: Admin/Orders
        public async Task<IActionResult> Orders()
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
            
            ViewBag.TotalOrders = orders.Count;
            ViewBag.PendingOrders = orders.Count(o => o.Status == "Pending");
            
            return View(orders);
        }

        // GET: Admin/OrderDetails/5
        public async Task<IActionResult> OrderDetails(int id)
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/UpdateOrderStatus
        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(int id, string status)
        {
            if (HttpContext.Session.GetString(AdminSessionKey) != "true")
            {
                return RedirectToAction("Login");
            }

            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật trạng thái đơn hàng thành công!";
            }

            return RedirectToAction("OrderDetails", new { id });
        }
    }
}

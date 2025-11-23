using Microsoft.AspNetCore.Mvc;
using PhoneStore.Data;
using PhoneStore.Models;
using System.Text.Json;

namespace PhoneStore.Controllers
{
    public class CartController : Controller
    {
        private readonly PhoneStoreContext _context;
        private const string CartSessionKey = "Cart";

        public CartController(PhoneStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Kiểm tra đăng nhập
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/Cart" });
            }

            var cart = GetCart();
            ViewBag.Total = cart.Sum(item => item.Price * item.Quantity);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            // Kiểm tra đăng nhập
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Request.Headers["Referer"].ToString() });
            }

            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            var cart = GetCart();
            var existingItem = cart.FirstOrDefault(item => item.PhoneId == id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    PhoneId = phone.Id,
                    Name = phone.Name,
                    Price = phone.Price,
                    Quantity = 1,
                    ImageUrl = phone.ImageUrl
                });
            }

            SaveCart(cart);
            TempData["Message"] = $"Đã thêm {phone.Name} vào giỏ hàng!";
            
            // Quay lại trang trước đó
            var referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(i => i.PhoneId == id);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(i => i.PhoneId == id);
            if (item != null && quantity > 0)
            {
                item.Quantity = quantity;
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            return string.IsNullOrEmpty(cartJson) 
                ? new List<CartItem>() 
                : JsonSerializer.Deserialize<List<CartItem>>(cartJson) ?? new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(CartSessionKey, cartJson);
        }

        // GET: Cart/Checkout
        public IActionResult Checkout()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/Cart/Checkout" });
            }

            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["Error"] = "Giỏ hàng trống!";
                return RedirectToAction("Index");
            }

            ViewBag.Total = cart.Sum(item => item.Price * item.Quantity);
            return View(cart);
        }

        // POST: Cart/Checkout
        [HttpPost]
        public async Task<IActionResult> Checkout(string fullName, string phone, string address, string note)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["Error"] = "Giỏ hàng trống!";
                return RedirectToAction("Index");
            }

            // Tạo đơn hàng
            var order = new Order
            {
                UserId = userId.Value,
                CustomerName = fullName,
                CustomerPhone = phone,
                ShippingAddress = address,
                Notes = note,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = cart.Sum(item => item.Price * item.Quantity)
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Tạo chi tiết đơn hàng
            foreach (var item in cart)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    PhoneId = item.PhoneId,
                    PhoneName = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                };
                _context.OrderDetails.Add(orderDetail);
            }

            await _context.SaveChangesAsync();

            // Xóa giỏ hàng
            HttpContext.Session.Remove(CartSessionKey);

            TempData["Message"] = "Đặt hàng thành công! Chúng tôi sẽ liên hệ với bạn sớm.";
            return RedirectToAction("OrderSuccess", new { id = order.Id });
        }

        // GET: Cart/OrderSuccess
        public async Task<IActionResult> OrderSuccess(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}

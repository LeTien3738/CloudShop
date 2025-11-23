using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    public class PhonesController : Controller
    {
        private readonly PhoneStoreContext _context;

        public PhonesController(PhoneStoreContext context)
        {
            _context = context;
        }

        // GET: Phones
        public async Task<IActionResult> Index(string searchString, string brand)
        {
            var phones = from p in _context.Phones
                         select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                phones = phones.Where(p => p.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(brand))
            {
                phones = phones.Where(p => p.Brand == brand);
            }

            ViewBag.Brands = await _context.Phones
                .Select(p => p.Brand)
                .Distinct()
                .ToListAsync();

            return View(await phones.ToListAsync());
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }
    }
}

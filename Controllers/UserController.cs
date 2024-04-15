using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "New record added!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Please fill in all the fields.";
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Record deleted!";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Record edited!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Please fill in all the fields.";
                return View(model);
            }
        }
    }
}

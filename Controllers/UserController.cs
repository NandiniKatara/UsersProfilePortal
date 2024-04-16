using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;
using System.Threading.Tasks;
using Portal.Models.Account;
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
            int Id = Convert.ToInt32(Request.Cookies["Id"]);
            var users = _context.Users.Where(i => i.UserId == Id);
            return View(await users.ToListAsync());
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
                int Id = Convert.ToInt32(Request.Cookies["Id"]);
                model.UserId = Id;

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
                int Id = Convert.ToInt32(Request.Cookies["Id"]);
                model.UserId = Id;

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
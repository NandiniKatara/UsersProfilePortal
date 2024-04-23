using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Account;
using Portal.Data;
using Portal.Models;
using System.Diagnostics;

namespace Portal.Controllers
{
    [Authorize]
    public class HomeController : Controller

    {
        private readonly ApplicationContext context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationContext context, ILogger<HomeController> logger)
        {
            this.context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string Id = Request.Cookies["Id"];
            string Username = Request.Cookies["Username"];
            string Email = Request.Cookies["Email"];
           

            ViewData["Id"] = Id;
            ViewData["Username"] = Username;
            ViewData["Email"] = Email;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

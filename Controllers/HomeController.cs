using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            var result = context.AccountUsers.ToList();
            return View(result);
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

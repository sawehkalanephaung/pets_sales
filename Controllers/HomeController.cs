using Microsoft.AspNetCore.Mvc;
using sales_pets.Models;
using System.Diagnostics;

namespace sales_pets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Landing()
        {
            ViewData["Title"] = "Welcome to Sales Pets";
            return View();
        }


        public IActionResult WeeklySales()
        {
            ViewData["Title"] = "Weekly Sales";
            return View();
        }

        public IActionResult DailySales()
        {
            ViewData["Title"] = "Daily Sales";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

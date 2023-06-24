using Microsoft.AspNetCore.Mvc;
using PreeceTechnology.Models;
using System.Diagnostics;

namespace PreeceTechnology.Controllers
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
            return View();
        }
        public IActionResult Stock(string name, string description, int instock, int needstock)
        {
            ViewData["Title"] = "Stock";
            ViewData["Message"] = "Stock for: " + name;
            ViewData["Description"] = description;
            ViewData["In Stock"] = instock;
            ViewData["Needed Stock"] = needstock;

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
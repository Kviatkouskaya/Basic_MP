using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System.Diagnostics;
using Northwind.Services;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeService _homeService;

        public HomeController(ILogger<HomeController> logger, HomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCategories()
        {
            var categories = _homeService.GetCategories();

            return View(categories);
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
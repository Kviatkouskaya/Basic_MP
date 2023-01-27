using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System.Diagnostics;
using Northwind.Services;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger,
                                CategoryService categoryService,
                                ProductService productService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productService = _productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            var categories = _categoryService.GetItems();

            return View(categories);
        }

        public IActionResult Products()
        {
            var products = _productService.GetItems();

            return View(products);
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
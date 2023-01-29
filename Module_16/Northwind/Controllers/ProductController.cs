using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Services;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public ProductController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetProductsWithCategoryName();

            return View(products);
        }

        public IActionResult ShowFormAddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(string productName, string supplierId, string categoryId,
                                        string quantityPerUnit, string unitPrice, string unitsInStock,
                                        string unitsOnOrder, string reorderLevel, string discontinued)
        {
            _productService.AddProduct(productName, supplierId, categoryId, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);

            return RedirectToAction("Index", "Product");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Northwind.Services;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        private const int LimitProductsOnPage = 10;

        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public ProductController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = LimitProductsOnPage > 0 ?
                _productService.GetProductsWithCategoryName(LimitProductsOnPage) :
                _productService.GetProductsWithCategoryName();

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

        public IActionResult ShowFormEditProduct(int productId)
        {
            var product = _productService.GetProduct(Convert.ToInt32(productId));

            return View(product);
        }

        public IActionResult EditProduct(int productId, string productName, string supplierId, string categoryId,
            string quantityPerUnit, string unitPrice, string unitsInStock,
            string unitsOnOrder, string reorderLevel, string discontinued)
        {
            _productService.UpdateProduct(productId, productName, supplierId, categoryId, quantityPerUnit, unitPrice, unitsInStock,
                unitsOnOrder, reorderLevel, discontinued);

            return RedirectToAction("Index", "Product");
        }
    }
}

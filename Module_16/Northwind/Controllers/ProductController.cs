using Microsoft.AspNetCore.Mvc;
using Northwind.Services;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;
        private IProductPageService _productPageService;

        public ProductController(ILogger<HomeController> logger, ProductService productService, IProductPageService productPageService)
        {
            _logger = logger;
            _productService = productService;
            _productPageService = productPageService;
        }

        public IActionResult Index()
        {
            var productLimit = Convert.ToInt32(_productPageService.GetUnits().ProductAmount);

            var products = _productService.GetProductsWithCategoryName(productLimit);

            return View(products);
        }

        public IActionResult ShowFormAddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(string productName, int supplierId, int categoryId,
            string quantityPerUnit, decimal unitPrice, Int16 unitsInStock,
            Int16 unitsOnOrder, Int16 reorderLevel, bool discontinued)
        {
            _productService.AddProduct(productName, supplierId, categoryId, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);

            return RedirectToAction("Index", "Product");
        }

        public IActionResult ShowFormEditProduct(int productId)
        {
            var product = _productService.GetProduct(Convert.ToInt32(productId));

            return View(product);
        }

        public async Task<IActionResult> EditProduct(int productId, string productName, int categoryId,
            string quantityPerUnit, decimal unitPrice, Int16 unitsInStock,
            Int16 unitsOnOrder, Int16 reorderLevel, bool discontinued)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ShowFormEditProduct", productId);
            }

            _productService.UpdateProduct(productId, productName, categoryId, quantityPerUnit, unitPrice, unitsInStock,
                unitsOnOrder, reorderLevel, discontinued);

            return RedirectToAction("Index", "Product");
        }
    }
}

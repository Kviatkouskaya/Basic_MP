using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private ProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetProduct(id);
        }

        [HttpPost]
        public void Post(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
            Int16 unitsInStock, Int16 unitsOnOrder, Int16 reorderLevel, bool discontinued)
        {
            _productService.CreateProduct(productName, supplierID, categoryID, quantityPerUnit, unitPrice,
                unitsInStock, unitsOnOrder, reorderLevel, discontinued);
        }

        [HttpPut("{id}")]
        public void Put(int productId, string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
            Int16 unitsInStock, Int16 unitsOnOrder, Int16 reorderLevel, bool discontinued)
        {
            _productService.UpdateProduct(productId, productName, supplierID, categoryID, quantityPerUnit,
                unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}

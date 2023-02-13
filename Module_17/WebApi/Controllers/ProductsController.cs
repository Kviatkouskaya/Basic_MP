using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductRepository<Product> _productRepository;

        public ProductsController(ILogger<ProductsController> logger, ProductRepository<Product> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetItems();
        }

        [HttpGet("pagenumber={pageNumber}%category={category}")]
        public IEnumerable<Product> GetProducts([FromHeader] ProductParameters productParameters)
        {
            return _productRepository.GetItems(productParameters);
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productRepository.GetItem(id);
        }

        [HttpPost]
        public void Post(Product product)
        {
            _productRepository.CreateItem(product);
        }

        [HttpPut]
        public void Put(int productId, string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
            Int16 unitsInStock, Int16 unitsOnOrder, Int16 reorderLevel, bool discontinued)
        {
            _productRepository.UpdateItem(new Product()
            {
                ProductID = productId,
                ProductName = productName,
                SupplierID = supplierID,
                CategoryID = categoryID,
                QuantityPerUnit = quantityPerUnit,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock,
                UnitsOnOrder = unitsOnOrder,
                ReorderLevel = reorderLevel,
                Discontinued = discontinued
            });
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productRepository.DeleteItem(id);
        }
    }
}

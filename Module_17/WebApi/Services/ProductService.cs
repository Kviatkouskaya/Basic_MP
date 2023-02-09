using WebApi.Models;

namespace WebApi.Services
{
    public class ProductService
    {
        private IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetItems();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetItem(id);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteItem(id);
        }

        public void UpdateProduct(int productId, string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
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

        public void CreateProduct(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
            Int16 unitsInStock, Int16 unitsOnOrder, Int16 reorderLevel, bool discontinued)
        {
            _productRepository.CreateItem(new Product()
            {
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

        public IEnumerable<Product> GetProducts(ProductParameters productParameters)
        {
            return _productRepository.GetItems(productParameters);
        }
    }
}
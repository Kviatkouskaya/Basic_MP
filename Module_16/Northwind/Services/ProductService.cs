using DataAccess.Models;
using DataAccess;
using Northwind.Models;

namespace Northwind.Services
{
    public class ProductService
    {
        private IRepository<ProductEntity> _productRepository;
        private IRepository<SupplierEntity> _supplierRepository;

        public ProductService(IRepository<ProductEntity> productRepository,
                            IRepository<SupplierEntity> supplierRepository)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        public List<ProductEntity> GetProducts()
        {
            return _productRepository.GetItems();
        }


        public List<ProductModel> GetProductsWithCategoryName()
        {
            var products = GetProducts();
            var suppliers = _supplierRepository.GetItems();

            var result = products.Select(p => new ProductModel()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                SupplierName = suppliers.Where(x => x.SupplierId == p.SupplierId)
                                        .Select(x => x.CompanyName).FirstOrDefault(),
                CategoryId = p.CategoryId,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder,
                ReorderLevel = p.ReorderLevel,
                Discontinued = p.Discontinued
            }).ToList();

            return result;
        }

        public void AddProduct(string productName, string supplierId, string categoryId,
                                string quantityPerUnit, string unitPrice, string unitsInStock,
                                string unitsOnOrder, string reorderLevel, string discontinued)
        {
            var product = new ProductEntity()
            {
                ProductName = productName,
                SupplierId = Convert.ToInt32(supplierId),
                CategoryId = (CategoryType)Convert.ToInt32(categoryId),
                QuantityPerUnit = quantityPerUnit,
                UnitPrice = Convert.ToDecimal(unitPrice),
                UnitsInStock = Convert.ToInt16(unitsInStock),
                UnitsOnOrder = Convert.ToInt16(unitsOnOrder),
                ReorderLevel = Convert.ToInt16(reorderLevel),
                Discontinued = Convert.ToBoolean(discontinued)
            };

            _productRepository.AddItem(product);
        }
    }
}

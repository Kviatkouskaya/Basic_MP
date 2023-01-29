using DataAccess;
using DataAccess.Models;
using Northwind.Models;

namespace Northwind.Services
{
    public class HomeService
    {
        private IRepository<ProductEntity> _productRepository;
        private IRepository<CategoryEntity> _categoryRepository;
        private IRepository<SupplierEntity> _supplierRepository;

        public HomeService(IRepository<ProductEntity> productRepository,
                            IRepository<CategoryEntity> categoryRepository,
                            IRepository<SupplierEntity> supplierRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public List<ProductEntity> GetProducts()
        {
            return _productRepository.GetItems();
        }

        public List<CategoryEntity> GetCategories()
        {
            return _categoryRepository.GetItems();
        }

        public List<SupplierEntity> GetSuppliers()
        {
            return _supplierRepository.GetItems();
        }

        public List<ProductModel> GetProductsWithCategoryName()
        {
            var products = GetProducts();
            var suppliers = GetSuppliers();

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
    }
}

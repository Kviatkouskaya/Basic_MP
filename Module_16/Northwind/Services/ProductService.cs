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

        public List<ProductModel> GetProductsWithCategoryName(int limit)
        {
            var products = _productRepository.GetItemsByLimit(limit);
            var suppliers = _supplierRepository.GetItems();

            var result = products.Select(p => new ProductModel()
            {
                ProductId = p.ProductID,
                ProductName = p.ProductName,
                SupplierName = suppliers.Where(x => x.SupplierID == p.SupplierId)
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

        public List<ProductModel> GetProductsWithCategoryName()
        {
            var products = GetProducts();
            var suppliers = _supplierRepository.GetItems();

            var result = products.Select(p => new ProductModel()
            {
                ProductId = p.ProductID,
                ProductName = p.ProductName,
                SupplierName = suppliers.Where(x => x.SupplierID == p.SupplierId)
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

        public void AddProduct(string productName, int supplierId, int categoryId,
            string quantityPerUnit, decimal unitPrice, Int16 unitsInStock,
            Int16 unitsOnOrder, Int16 reorderLevel, bool discontinued)
        {
            var product = new ProductEntity()
            {
                ProductName = productName,
                SupplierId = supplierId,
                CategoryId = (CategoryType)categoryId,
                QuantityPerUnit = quantityPerUnit,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock,
                UnitsOnOrder = unitsOnOrder,
                ReorderLevel = reorderLevel,
                Discontinued = discontinued
            };

            _productRepository.AddItem(product);
        }

        public void UpdateProduct(int productId, string productName, int categoryId,
                                    string quantityPerUnit, decimal unitPrice, Int16 unitsInStock,
                                    Int16 unitsOnOrder, Int16 reorderLevel, bool discontinued)
        {
            var oldProductEntity = _productRepository.GetItem(productId);

            var product = new ProductEntity()
            {
                ProductName = productName,
                CategoryId = (CategoryType)categoryId,
                SupplierId = oldProductEntity.SupplierId,
                QuantityPerUnit = quantityPerUnit,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock,
                UnitsOnOrder = unitsOnOrder,
                ReorderLevel = reorderLevel,
                Discontinued = discontinued
            };

            _productRepository.UpdateItem(product);
        }

        public ProductModel GetProduct(int productId)
        {

            var item = _productRepository.GetItem(productId);
            var supplierItem = _supplierRepository.GetItem(item.SupplierId);

            return new ProductModel()
            {
                ProductId = item.ProductID,
                ProductName = item.ProductName,
                SupplierName = supplierItem.CompanyName,
                CategoryId = item.CategoryId,
                QuantityPerUnit = item.QuantityPerUnit,
                UnitPrice = item.UnitPrice,
                UnitsInStock = item.UnitsInStock,
                UnitsOnOrder = item.UnitsOnOrder,
                ReorderLevel = item.ReorderLevel,
                Discontinued = item.Discontinued
            };
        }
    }
}

using DataAccess;
using DataAccess.Models;

namespace Northwind.Services
{
    public class ProductService
    {
        private IRepository<ProductEntity> _productRepository;

        public ProductService(IRepository<ProductEntity> repository)
        {
            this._productRepository = repository;
        }

        public List<ProductEntity> GetItems()
        {
            return _productRepository.GetItems();
        }
    }
}

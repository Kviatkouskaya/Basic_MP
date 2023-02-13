using DataAccess;
using DataAccess.Models;

namespace Northwind.Services
{
    public class HomeService
    {
        private IRepository<CategoryEntity> _categoryRepository;
        private IRepository<SupplierEntity> _supplierRepository;

        public HomeService(IRepository<CategoryEntity> categoryRepository,
                            IRepository<SupplierEntity> supplierRepository)
        {
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public List<CategoryEntity> GetCategories()
        {
            return _categoryRepository.GetItems();
        }

        public List<SupplierEntity> GetSuppliers()
        {
            return _supplierRepository.GetItems();
        }
    }
}

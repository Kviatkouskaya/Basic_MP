using DataAccess;

namespace Northwind.Services
{
    public class CategoryService
    {
        private IRepository<CategoryEntity> _categoryRepository;

        public CategoryService(IRepository<CategoryEntity> repository)
        {
            this._categoryRepository = repository;
        }

        public List<CategoryEntity> GetItems()
        {
            return _categoryRepository.GetItems();
        }
    }
}

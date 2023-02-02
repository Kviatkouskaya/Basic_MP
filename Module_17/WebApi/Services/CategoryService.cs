using WebApi.Models;

namespace WebApi.Services
{
    public class CategoryService
    {
        private IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetItems();
        }

        public Category GetCategory(int id)
        {
            return _categoryRepository.GetItem(id);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteItem(id);
        }

        public void UpdateCategory(int id, string categoryName, string description)
        {
            _categoryRepository.UpdateItem(new Category()
            {
                CategoryID = id,
                CategoryName = categoryName,
                Description = description
            });
        }

        public void CreateCategory(string categoryName, string description)
        {
            _categoryRepository.CreateItem(new Category()
            {
                CategoryName = categoryName,
                Description = description
            });
        }
    }
}

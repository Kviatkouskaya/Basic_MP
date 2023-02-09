using WebApi.Models;

namespace WebApi.Services
{
    public class CategoryRepository<T> : IRepository<T> where T : Category
    {
        private readonly WebApiContext _dbContext;

        public CategoryRepository(WebApiContext webApiContext) => _dbContext = webApiContext;

        public void CreateItem(T item)
        {
            _dbContext.Categories.Add(item);
            _dbContext.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = _dbContext.Categories.Where(x => x.CategoryID == id).FirstOrDefault();

            _dbContext.Categories.Remove(item);
            _dbContext.SaveChanges();
        }

        public T GetItem(int id)
        {
            return (T)_dbContext.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
        }

        public List<T> GetItems()
        {
            return _dbContext.Categories.Select(x => (T)x).ToList();
        }

        public IEnumerable<T> GetItems(ProductParameters productParameters) => throw new NotImplementedException();

        public void UpdateItem(T item)
        {
            _dbContext.Categories.Update(item);
            _dbContext.SaveChanges();
        }
    }
}

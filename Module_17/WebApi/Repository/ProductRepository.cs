using WebApi.Models;
using WebApi.Services;

namespace WebApi.Repository
{
    public class ProductRepository<T> : IRepository<T> where T : Product
    {
        private readonly WebApiContext _dbContext;

        public ProductRepository(WebApiContext dbContext) => _dbContext = dbContext;

        public void CreateItem(T item)
        {
            _dbContext.Products.Add(item);
            _dbContext.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = _dbContext.Products.Where(x => x.ProductID == id).FirstOrDefault();

            _dbContext.Products.Remove(item);
            _dbContext.SaveChanges();
        }

        public T GetItem(int id)
        {
            return (T)_dbContext.Products.Where(x => x.ProductID == id).FirstOrDefault();
        }

        public List<T> GetItems()
        {
            var products = _dbContext.Products.ToList();
            var result = new List<T>();

            foreach (var item in products)
            {
                result.Add((T)item);
            }

            return result;
        }

        public void UpdateItem(T item)
        {
            _dbContext.Products.Update(item);
            _dbContext.SaveChanges();
        }
    }
}

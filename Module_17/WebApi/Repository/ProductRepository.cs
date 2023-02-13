using Microsoft.EntityFrameworkCore;
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
            return _dbContext.Products.Select(x => (T)x).ToList();
        }

        public IEnumerable<T> GetItems(ProductParameters productParameters)
        {
            return _dbContext.Products
                .Where(x => x.CategoryID != (int)productParameters.CategoryType)
                 .OrderBy(x => x.ProductName)
                 .Skip(productParameters.PageNumber)
                 .Take(productParameters.PageSize)
                 .Select(x => (T)x)
                 .ToList();
        }

        public void UpdateItem(T item)
        {
            _dbContext.Products.Update(item);
            _dbContext.SaveChanges();
        }

    }
}

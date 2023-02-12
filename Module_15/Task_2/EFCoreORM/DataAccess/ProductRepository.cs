using System.Linq;

namespace DataAccess
{
    public class ProductRepository
    {
        private AppContext _context;

        public ProductRepository()
        {
            _context = new AppContext();
        }
        public void Create(ProductModel item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Products.Remove(new ProductModel() { Id = id });
            _context.SaveChanges();
        }

        public ProductModel Get(int id)
        {
            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<ProductModel> GetItems()
        {
            return _context.Products.ToList();
        }

        public void Update(ProductModel item)
        {
            _context.Products.Update(item);
            _context.SaveChanges();
        }
    }
}

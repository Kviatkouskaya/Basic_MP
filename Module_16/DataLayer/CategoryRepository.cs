namespace DataAccess
{
    public class CategoryRepository<T> : IRepository<T> where T : CategoryEntity
    {
        private NorthwindContext _context;
        public CategoryRepository(NorthwindContext context) => _context = context;

        public void AddItem(T item) => throw new NotImplementedException();
        public T GetItem(int itemId) => throw new NotImplementedException();

        public List<T> GetItems()
        {
            var list = _context.Categories.ToList();

            var result = new List<T>();
            foreach (var item in list)
            {
                result.Add((T)item);
            }

            return result;
        }

        public List<T> GetItemsByLimit(int limit) => throw new NotImplementedException();
    }
}
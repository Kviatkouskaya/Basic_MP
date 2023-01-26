namespace DataAccess
{
    public class CategoryRepository<T> : IRepository<T> where T : CategoryEntity
    {
        private NorthwindContext _context;
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
    }
}
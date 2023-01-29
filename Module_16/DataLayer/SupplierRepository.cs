using DataAccess.Models;

namespace DataAccess
{
    public class SupplierRepository<T> : IRepository<T> where T : SupplierEntity
    {
        private NorthwindContext _context;

        public SupplierRepository(NorthwindContext context) => _context = context;

        public void AddItem(T product) => throw new NotImplementedException();

        public List<T> GetItems()
        {
            var list = _context.Suppliers.ToList();

            var result = new List<T>();
            foreach (var item in list)
            {
                result.Add((T)item);
            }

            return result;
        }
    }
}

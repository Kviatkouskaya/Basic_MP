using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess
{
    public class ProductRepository<T> : IRepository<T> where T : ProductEntity
    {
        private NorthwindContext _context;
        public ProductRepository(NorthwindContext context) => _context = context;

        public List<T> GetItems()
        {
            var list = _context.Products.ToList();

            var result = new List<T>();
            foreach (var item in list)
            {
                result.Add((T)item);
            }

            return result;
        }
    }
}

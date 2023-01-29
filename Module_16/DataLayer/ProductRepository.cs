﻿using DataAccess.Models;

namespace DataAccess
{
    public class ProductRepository<T> : IRepository<T> where T : ProductEntity
    {
        private NorthwindContext _context;

        public ProductRepository(NorthwindContext context) => _context = context;

        public void AddItem(T product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

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

        public List<T> GetItemsByLimit(int limit)
        {
            var list = _context.Products.Take(limit).ToList();

            var result = new List<T>();
            foreach (var item in list)
            {
                result.Add((T)item);
            }

            return result;
        }
    }
}

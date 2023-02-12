using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLibrary
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        T Get(int id);
        List<T> GetItems();
        void Update(T item);
    }
}

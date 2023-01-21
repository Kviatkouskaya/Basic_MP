using System.Collections.Generic;

namespace Storage
{
    public interface IProvider<T>
    {
        public void SaveItem(T item);

        public T SearchItemById(int id);
    }
}

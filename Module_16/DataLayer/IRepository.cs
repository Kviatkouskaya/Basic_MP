namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        void AddItem(T item);
        T GetItem(int itemId);
        List<T> GetItems();
        public List<T> GetItemsByLimit(int limit);
        public void UpdateItem(T item);
    }
}

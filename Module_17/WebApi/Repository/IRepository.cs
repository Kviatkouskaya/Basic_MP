namespace WebApi.Services
{
    public interface IRepository<T> where T : class
    {
        List<T> GetItems();
        void CreateItem(T item);
        T GetItem(int id);
        void UpdateItem(T item);
        void DeleteItem(int id);
    }
}

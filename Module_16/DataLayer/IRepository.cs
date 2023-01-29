namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        void AddItem(T product);
        List<T> GetItems();
    }
}

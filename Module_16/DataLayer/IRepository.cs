namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        List<T> GetItems();
    }
}

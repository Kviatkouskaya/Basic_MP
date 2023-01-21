namespace Service
{
    public interface IService<T>
    {
        public void SaveItem(T document);

        public T SearchItemById(int itemId);
    }
}

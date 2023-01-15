using System;
using System.Runtime.Caching;

namespace Service
{
    public class CacheService<T> : ICacheService<T> where T : class
    {
        private ObjectCache _memoryCache = MemoryCache.Default;

        public T GetData<T>(string key)
        {
            try
            {
                T item = (T)_memoryCache.Get(key);

                return item;
            }
            catch (Exception)
            {
                throw new Exception(key);
            }
        }

        public object RemoveData(string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    return _memoryCache.Remove(key);
                }
            }
            catch (Exception)
            {
                throw new Exception(key);
            }

            return false;
        }

        public void SetData<T>(string key, T value)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    var typeFullName = value.GetType().FullName;
                    var policy = GetCachedItemPolicy(typeFullName);

                    _memoryCache.Set(key, value, policy);
                }
            }
            catch (Exception)
            {
                throw new Exception(key);
            }
        }

        private CacheItemPolicy GetCachedItemPolicy(string typeFullName)
        {
            var policy = new CacheItemPolicy();

            // Model.Document & Model.BookBase have no cache policy

            switch (typeFullName)
            {
                case "Model.Book":
                    policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5.0);
                    break;
                case "Model.LocalizedBook":
                    policy.SlidingExpiration = TimeSpan.FromMinutes(15);
                    break;
                case "Model.Patent":
                    policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(15.0);
                    break;
                case "Model.Magazine":
                    policy.SlidingExpiration = TimeSpan.FromMinutes(10);
                    break;
                default:
                    break;
            }

            return policy;
        }
    }
}

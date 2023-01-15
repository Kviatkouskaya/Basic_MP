using System;
using System.Runtime.Caching;

namespace Service
{
    public interface ICacheService<T>
    {
        T GetData<T>(string key);

        void SetData<T>(string key, T value);

        object RemoveData(string key);
    }
}

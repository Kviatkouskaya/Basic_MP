using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using Model;
using Storage;

namespace Service
{
    public class FileService<T> : IService<T> where T : Document
    {
        private readonly IProvider<T> _storageProvider;

        private readonly ICacheService<T> _cacheService;

        public FileService()
        {
            _storageProvider = new JsonFileProvider<T>();
            _cacheService = new CacheService<T>();
        }

        public void SaveItem(T doc)
        {
            _storageProvider.SaveItem(doc);
        }

        public T SearchItemById(int id)
        {
            var cachedItem = _cacheService.GetData<T>(id.ToString());

            if (cachedItem != null)
            {
                var result = new List<T>
                {
                    cachedItem
                };

                return result.FirstOrDefault();
            }

            var item = _storageProvider.SearchItemById(id);

            _cacheService.SetData(item.Id.ToString(), item);


            return item;
        }

    }
}

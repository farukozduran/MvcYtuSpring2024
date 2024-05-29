using Caching.Abstract;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching.Concrete
{
    public class MemoryCacheProvider(IMemoryCache memoryCache) : ICacheProvider
    {
        //readonly IMemoryCache _memoryCache = memoryCache;

        bool ICacheProvider.Any(string key)
        {
            return  memoryCache.Get(key) != null;
        }

        public T? Get<T>(string key)
        {
            return memoryCache.Get<T>(key);
        }

        bool ICacheProvider.Remove(string key)
        {
            memoryCache.Remove(key);
            return true;
        }

        void ICacheProvider.Set<T>(string key, T value, TimeSpan expiration)
        {
            memoryCache.Set<T>(key, value, expiration);
        }
    }
}

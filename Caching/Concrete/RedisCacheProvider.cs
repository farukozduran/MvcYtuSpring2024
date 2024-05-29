using Caching.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching.Concrete
{
    public class RedisCacheProvider : ICacheProvider
    {
        IDatabase _database;
        IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheProvider()
        {
            _database = ConnectionMultiplexer.Connect("localhost:6379").GetDatabase(0);
        }
        bool ICacheProvider.Any(string key)
        {
            return _database.KeyExists(key);
        }

        T? ICacheProvider.Get<T>(string key) where T : default
        {
            var result = _database.StringGet(key);

            var deserialize = JsonConvert.DeserializeObject<T>(result);

            return deserialize;
        }

        bool ICacheProvider.Remove(string key)
        {
            return _database.KeyDelete(key);
        }

        void ICacheProvider.Set<T>(string key, T value, TimeSpan expiration)
        {
            var result = JsonConvert.SerializeObject(value);
            _database.StringSet(key,result,expiration);
        }
    }
}

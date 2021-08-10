using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Services.CacheService
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IEnumerable<T> GetCache<T>(string key)
        {
            IEnumerable<T> value;
            _memoryCache.TryGetValue(key, out value);
            return value;
        }
        public void SetCache<T>(string key, IEnumerable<T> value)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(60),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(30),
                Size = 1024,
            };
            _memoryCache.Set(key, value, cacheExpiryOptions);
        }
    }
}

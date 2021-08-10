using System.Collections.Generic;

namespace Task1.Services.CacheService
{
    public interface IMemoryCacheService
    {
        IEnumerable<T> GetCache<T>(string key);
        void SetCache<T>(string key, IEnumerable<T> value);
    }
}

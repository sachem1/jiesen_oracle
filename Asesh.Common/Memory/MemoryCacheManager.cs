using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Asesh.Common.Memory
{
    public class MemoryCacheManager
    {
        private static MemoryCache cache = MemoryCache.Default;

        public static void Set(string key, object obj, int seconds = 7200)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(seconds)
            };

            cache.Set(key, obj, policy);
        }

        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)cache.Get(key);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}

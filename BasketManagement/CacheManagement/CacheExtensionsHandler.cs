using System.Text;
using System.Threading.Tasks;
using BasketManagement.Common.Utils;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BasketManagement.CacheManagement
{
    /**
     * Extension methods that provide ease of access as well as highly optimized compression
     * by noushad
     */
    public static class CacheExtensionsHandler
    {
        public static async Task<T> GetObjectAsync<T>(this IDistributedCache cache, string key) where T : class
        {
            var json =
                await cache.GetAsync(key);

            if (json == null)
            {
                return null;
            }

            var data = DataCompressor.Decompress(Encoding.UTF8.GetString(json));

            var storedObject = JsonConvert.DeserializeObject<T>(data, GetJsonSettings());

            return storedObject;
        }

        public static async Task SaveObjectAsync<T>(this IDistributedCache cache, string key, T item,
            DistributedCacheEntryOptions options)
        {
            var data = DataCompressor.Compress(JsonConvert.SerializeObject(item, GetJsonSettings()));
            await cache.SetStringAsync(key,
                data, options);
        }


        public static JsonSerializerSettings GetJsonSettings()
        {
            return new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }
    }
}
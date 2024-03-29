﻿using System.Text;
using System.Threading.Tasks;
using Catalogue.Common.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Catalogue.Common.Utils
{
    /**
     * Extension methods that provide ease of access as well as highly optimized compression
     * by noushad
     */
    public static class CacheExtensionsHandler
    {
        public static async Task<T> GetObjectAsync<T>(this IDistributedCache cache, CacheKeys key,
            long additionalKey = 0) where T : class
        {
            var json =
                await cache.GetAsync(MakeKey(key, additionalKey));

            if (json == null)
            {
                return null;
            }

            var data = DataCompressor.Decompress(Encoding.UTF8.GetString(json));

            var storedObject = JsonConvert.DeserializeObject<T>(data, HelperFunctions.GetJsonSettings());

            return storedObject;
        }

        public static async Task SaveObjectAsync<T>(this IDistributedCache cache, CacheKeys key, T item,
            DistributedCacheEntryOptions options, long additionalKey = 0)
        {
            var data = DataCompressor.Compress(JsonConvert.SerializeObject(item, HelperFunctions.GetJsonSettings()));
            await cache.SetStringAsync(MakeKey(key, additionalKey),
                data, options);
        }

        private static string MakeKey(CacheKeys key, long additionalKey)
        {
            return key.ToString() + additionalKey;
        }
    }
}
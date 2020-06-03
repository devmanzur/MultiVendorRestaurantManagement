using System;
using System.Threading.Tasks;
using BasketManagement.CacheManagement;
using BasketManagement.Common.Utils;
using BasketManagement.Domain.Baskets;
using BasketManagement.Domain.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Caching.Distributed;

namespace BasketManagement.Services
{
    public class BasketService : IBasketService
    {
        private readonly IDistributedCache _cache;

        public BasketService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<Result> AddToBasket(string userId, string sessionId, BasketItem item)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(BasketCache.DurationInMinutes));

            var basket = await GetBasket(userId, sessionId);
            basket.AddItem(item);

            await _cache.SaveObjectAsync(KeyMaker.GetBasketKey(userId, sessionId), basket, options);

            return Result.Ok();
        }

        public async Task<Result> ClearBasket(string userId, string sessionId)
        {
            var basket = await _cache.GetObjectAsync<Basket>(KeyMaker.GetBasketKey(userId, sessionId));
            if (basket.HasValue())
            {
                await _cache.RemoveAsync(KeyMaker.GetBasketKey(userId, sessionId));
                return Result.Ok();
            }

            return Result.Failure("basket not found");
        }

        private async Task<Basket> GetBasket(string userId, string sessionId)
        {
            var basket = await _cache.GetObjectAsync<Basket>(KeyMaker.GetBasketKey(userId, sessionId));

            if (basket.HasNoValue())
            {
                basket = Basket.MakeNew(userId, sessionId);
            }

            return basket;
        }
    }
}
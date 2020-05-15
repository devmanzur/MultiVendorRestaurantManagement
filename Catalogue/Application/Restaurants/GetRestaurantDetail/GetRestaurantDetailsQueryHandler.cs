using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using Catalogue.Common.Cache;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Utils;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;

namespace Catalogue.Application.Restaurants.GetRestaurantDetail
{
    public class GetRestaurantDetailsQueryHandler : IQueryHandler<GetRestaurantDetailQuery, Result<RestaurantDetailDto>>
    {
        private readonly DocumentCollection _collection;
        private readonly IDistributedCache _cache;
        private const int CacheDurationInMinutes = 30;

        public GetRestaurantDetailsQueryHandler(DocumentCollection collection, IDistributedCache cache)
        {
            _collection = collection;
            _cache = cache;
        }

        public async Task<Result<RestaurantDetailDto>> Handle(GetRestaurantDetailQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _cache.GetObjectAsync<RestaurantDetailDto>(CacheKeys.RestaurantDetail,
                additionalKey: request.RestaurantId);

            if (result.HasNoValue())
            {
                result = await LoadFromCollection(request.RestaurantId, cancellationToken);

                if (result.HasValue())
                {
                    await CacheData(result);
                }

                return Result.Ok(result);
            }

            return Result.Failure<RestaurantDetailDto>("not found");
        }

        private async Task CacheData(RestaurantDetailDto result)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheDurationInMinutes));

            await _cache.SaveObjectAsync(CacheKeys.RestaurantDetail, result, options);
        }

        private async Task<RestaurantDetailDto> LoadFromCollection(long restaurantId,
            CancellationToken cancellationToken)
        {
            var restaurant = await _collection.RestaurantsCollection
                .Find(x => x.RestaurantId == restaurantId)
                .FirstOrDefaultAsync(cancellationToken);
            if (!restaurant.HasValue()) return null;

            var dto = new RestaurantDetailDto(
                restaurant.RestaurantId,
                restaurant.Name,
                restaurant.Description,
                restaurant.DescriptionEng,
                restaurant.PhoneNumber,
                restaurant.LocalityId,
                restaurant.State,
                restaurant.OpeningHour,
                restaurant.ClosingHour,
                restaurant.ImageUrl,
                restaurant.Rating,
                restaurant.TotalRatingsCount,
                restaurant.CategoryId,
                restaurant.CategoryName
            );

            var menus = new List<MenuDetailDto>();

            if (restaurant.Menus.HasValue())
            {
                restaurant.Menus.ForEach(async menu =>
                {
                    var foods = await _collection.FoodCollection.Find(f => f.MenuId == menu.MenuId)
                        .SortByDescending(x => x.Name)
                        .Project(Projections.MinimalFoodProjection())
                        .ToListAsync(cancellationToken);
                    menus.Add(new MenuDetailDto(menu, foods));
                });

                dto.SetMenuDetail(menus);
            }

            return dto;
        }
    }
}
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using Catalogue.Common.Cache;
using Catalogue.Common.Invariants;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using Catalogue.Infrastructure.ValueObject;
using Catalogue.Utils;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;

namespace Catalogue.Application.Home
{
    public class GetHomeDataQueryHandler : IQueryHandler<GetHomeDataQuery, Result<HomeInformationDto>>
    {
        private const int StandardLimit = 5;
        private const int HomePageFoodLimit = 20;
        private const int CacheDurationInMinutes = 30;
        private readonly DocumentCollection _collection;
        private readonly IDistributedCache _cache;

        public GetHomeDataQueryHandler(DocumentCollection collection, IDistributedCache cache)
        {
            _collection = collection;
            _cache = cache;
        }

        public async Task<Result<HomeInformationDto>> Handle(GetHomeDataQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _cache.GetObjectAsync<HomeInformationDto>(CacheKeys.HomeData);
            if (result.HasNoValue())
            {
                result = await LoadFromCollection(cancellationToken);

                await CacheData(result);
            }

            return Result.Ok(result);
        }

        private async Task CacheData(HomeInformationDto result)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheDurationInMinutes));

            await _cache.SaveObjectAsync(CacheKeys.HomeData, result, options);
        }

        private async Task<HomeInformationDto> LoadFromCollection(CancellationToken cancellationToken)
        {
            var result = new HomeInformationDto
            {
                Categories = await _collection.CategoriesCollection.Find(Filter())
                    .SortByDescending(x => x.Name)
                    .Limit(StandardLimit)
                    .Project(Projections.MinimalCategoryProjection())
                    .ToListAsync(cancellationToken),
                Foods = await _collection.FoodCollection.Find(Filters.EmptyFilter<FoodDocument>())
                    .SortByDescending(x => x.Name)
                    .Limit(HomePageFoodLimit)
                    .Project(Projections.MinimalFoodProjection())
                    .ToListAsync(cancellationToken),
                Restaurants = await _collection.RestaurantsCollection.Find(Filters.EmptyFilter<RestaurantDocument>())
                    .SortByDescending(x => x.Id)
                    .Limit(StandardLimit)
                    .Project(Projections.MinimalRestaurantProjection())
                    .ToListAsync(cancellationToken),
                Offers = await _collection.DealCollection.Find(Filters.EmptyFilter<DealDocument>())
                    .SortByDescending(x => x.EndDate)
                    .Limit(StandardLimit)
                    .Project(Projections.MinimalDealProjection())
                    .ToListAsync(cancellationToken)
            };
            return result;
        }

        private static Expression<Func<CategoryDocument, bool>> Filter()
        {
            return x => x.Categorize.Equals(Categorize.Food.ToString());
        }
    }
}
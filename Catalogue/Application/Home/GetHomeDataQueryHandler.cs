using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using Catalogue.Common.Invariants;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using Catalogue.Infrastructure.Mongo;
using Catalogue.Infrastructure.Mongo.Documents;
using Catalogue.Infrastructure.ValueObject;
using CSharpFunctionalExtensions;
using MongoDB.Driver;

namespace Catalogue.Application.Home
{
    public class GetHomeDataQueryHandler : IQueryHandler<GetHomeDataQuery, Result<HomeInformationDto>>
    {
        private const int StandardLimit = 5;
        private const int HomePageFoodLimit = 20;
        private readonly DocumentCollection _collection;

        public GetHomeDataQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<HomeInformationDto>> Handle(GetHomeDataQuery request,
            CancellationToken cancellationToken)
        {
            var result = new HomeInformationDto
            {
                Categories = await _collection.CategoriesCollection.Find(Filter())
                    .SortByDescending(x => x.Name)
                    .Limit(StandardLimit)
                    .Project(MinimalCategoryProjection())
                    .ToListAsync(cancellationToken),
                Foods = await _collection.FoodCollection.Find(EmptyFilter<FoodDocument>())
                    .SortByDescending(x => x.Name)
                    .Limit(HomePageFoodLimit)
                    .Project(MinimalFoodProjection())
                    .ToListAsync(cancellationToken),
                Restaurants = await _collection.RestaurantsCollection.Find(EmptyFilter<RestaurantDocument>())
                    .SortByDescending(x => x.Id)
                    .Limit(StandardLimit)
                    .Project(MinimalRestaurantProjection())
                    .ToListAsync(cancellationToken),
                Offers = await _collection.DealCollection.Find(EmptyFilter<DealDocument>())
                    .SortByDescending(x => x.EndDate)
                    .Limit(StandardLimit)
                    .Project(MinimalDealProjection())
                    .ToListAsync(cancellationToken)
            };

            return Result.Ok(result);
        }

        private static Expression<Func<CategoryDocument, bool>> Filter()
        {
            return x => x.Categorize.Equals(Categorize.Food.ToString());
        }

        private static Expression<Func<CategoryDocument, CategoryMinimalDto>> MinimalCategoryProjection()
        {
            return x => new CategoryMinimalDto(x.CategoryId, x.Name, x.ImageUrl);
        }

        private static Expression<Func<FoodDocument, FoodMinimalDto>> MinimalFoodProjection()
        {
            return x => new FoodMinimalDto(x.FoodId, x.Name, x.RestaurantId, x.RestaurantName, x.CategoryId,
                x.CategoryName, x.Rating, x.OldUnitPrice, x.UnitPrice, MoneyValue.Of(x.UnitPrice).PriceTag,
                x.DealId, x.DealDescription);
        }

        private static Expression<Func<RestaurantDocument, RestaurantMinimalDto>> MinimalRestaurantProjection()
        {
            return x => new RestaurantMinimalDto(x.RestaurantId, x.Name, x.Rating, x.ImageUrl, x.GetState());
        }

        private static Expression<Func<DealDocument, OfferMinimalDto>> MinimalDealProjection()
        {
            return x => new OfferMinimalDto(x.DealId, x.Name, x.ImageUrl, x.Description);
        }

        private static FilterDefinition<T> EmptyFilter<T>() where T : BaseDocument
        {
            return Builders<T>.Filter.Empty;
        }
    }
}
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using CSharpFunctionalExtensions;
using MessengerBotAPI.ApiContract.Pagination;
using MessengerBotAPI.ApiContract.Response;
using MessengerBotAPI.Application.Base;
using MessengerBotAPI.Utils;
using MongoDB.Driver;

namespace MessengerBotAPI.Application.Restaurant.GetRestaurantList
{
    public class GetRestaurantListQueryHandler : IQueryHandler<GetRestaurantListQuery, Result<IPagedList<RestaurantMinimalDto>>>
    {
        private readonly DocumentCollection _collection;
        private const int DefaultPageSize = 20;
        private const string ShopIdentifierKey = "shop_identifier";
        public GetRestaurantListQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<IPagedList<RestaurantMinimalDto>>> Handle(GetRestaurantListQuery request,
            CancellationToken cancellationToken)
        {
            var type = request.QueryResult.Parameters.Fields.FirstOrDefault(x => x.Key == ShopIdentifierKey).Value
                .StringValue;
            var restaurants = await _collection.RestaurantsCollection
                .Find(ElemMatch(type))
                .SortByDescending(x => x.Rating)
                .Skip(PaginationHelper.Skip())
                .Limit(DefaultPageSize)
                .Project(Projections.MinimalRestaurantProjection())
                .ToListAsync(cancellationToken);

            return Result.Ok(restaurants.ToPagedList());
        }

        private static FilterDefinition<RestaurantDocument> ElemMatch(string type)
        {
            return Builders<RestaurantDocument>.Filter.ElemMatch(
                x => x.Categories,
                c => c.Name == type);
        }
    }
    
}
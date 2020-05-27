using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using CSharpFunctionalExtensions;
using MessengerBotAPI.Application.Base;
using MongoDB.Driver;

namespace MessengerBotAPI.Application.Restaurant.GetMenu
{
    public class GetRestaurantMenuQueryHandler : IQueryHandler<GetRestaurantMenuQuery, Result<List<MenuRecord>>>
    {
        private readonly DocumentCollection _collection;
        private const string ShopKey = "shop";

        public GetRestaurantMenuQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<List<MenuRecord>>> Handle(GetRestaurantMenuQuery request,
            CancellationToken cancellationToken)
        {
            var name = request.QueryResult.Parameters.Fields.FirstOrDefault(x => x.Key == ShopKey).Value
                .StringValue;

            var restaurant = await _collection.RestaurantsCollection.Find(Equals(name))
                .FirstOrDefaultAsync(cancellationToken);

            return restaurant.HasValue()
                ? Result.Ok(restaurant.Menus)
                : Result.Failure<List<MenuRecord>>("restaurant not found");
        }

        private static FilterDefinition<RestaurantDocument> Equals(string name)
        {
            return Builders<RestaurantDocument>.Filter.Eq(x => x.Name, name);
        }
    }
}
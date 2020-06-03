using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using CSharpFunctionalExtensions;
using MessengerBotAPI.Application.Base;
using MessengerBotAPI.Application.Restaurant.GetCategoryMenu;
using MongoDB.Driver;

namespace MessengerBotAPI.Application.GetCategoryMenu
{
    public class
        GetCategoryMenuQueryHandler : IQueryHandler<GetCategoryMenuQuery, Result<List<MenuRecord>>>
    {
        private readonly DocumentCollection _collection;
        private const string CategoryIdentifierKey = "group";
        private const string ShopIdentifierKey = "shop";
        private const int DefaultPageSize = 20;


        public GetCategoryMenuQueryHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task<Result<List<MenuRecord>>> Handle(GetCategoryMenuQuery request,
            CancellationToken cancellationToken)
        {
            var category = request.QueryResult.Parameters.Fields.FirstOrDefault(x => x.Key == CategoryIdentifierKey)
                .Value
                .StringValue;

            // var shop = request.QueryResult.Parameters.Fields.FirstOrDefault(x => x.Key == ShopIdentifierKey).Value
            //     .StringValue;

            if (category.HasNoValue())
                return Result.Failure<List<MenuRecord>>(
                    "please mention a category you would like to explore");

            var menus = await _collection.RestaurantsCollection
                .Find(ElemMatch(category))
                .Project(x => x.Menus.FirstOrDefault(m => m.Name == category))
                .ToListAsync(cancellationToken);

            return Result.Ok(menus);
        }

        private static FilterDefinition<RestaurantDocument> ElemMatch(string category)
        {
            return Builders<RestaurantDocument>.Filter.ElemMatch(
                x => x.Menus,
                c => c.Name == category);
        }
    }
}
using System;
using System.Linq.Expressions;
using Catalogue.Infrastracture.Mongo.Documents;
using MessengerBotAPI.ApiContract.Response;

namespace MessengerBotAPI.Utils
{
    public static class Projections
    {
        public static Expression<Func<RestaurantDocument, RestaurantMinimalDto>> MinimalRestaurantProjection()
        {
            return x => new RestaurantMinimalDto(x.RestaurantId, x.Name, x.Rating, x.ImageUrl, x.GetState());
        }
    }
}
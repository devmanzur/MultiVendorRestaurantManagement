using Catalogue.ApiContract.Response;
using Catalogue.Base;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Restaurants.GetRestaurantDetail
{
    public class GetRestaurantDetailQuery : IQuery<Result<RestaurantDetailDto>>
    {
        public long RestaurantId { get; }

        public GetRestaurantDetailQuery(long restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
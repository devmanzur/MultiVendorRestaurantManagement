using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.Converters;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant
{
    public class RestaurantRegisteredEventHandler : INotificationHandler<RestaurantRegisteredEvent>
    {
        private readonly DocumentCollection _documentCollection;
        private readonly ITableDataProvider _tableDataProvider;

        public RestaurantRegisteredEventHandler(DocumentCollection documentCollection,
            ITableDataProvider tableDataProvider)
        {
            _documentCollection = documentCollection;
            _tableDataProvider = tableDataProvider;
        }

        public async Task Handle(RestaurantRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var restaurant = await _tableDataProvider.GetRestaurant(notification.PhoneNumber);
            var geographicLocation = await _tableDataProvider.GetGeoGraphicLocation(restaurant.Id);
            var cuisines = await _tableDataProvider.GetCuisineList(notification.CuisineIds);
            var categories = await _tableDataProvider.GetCategoryList(notification.CategoryIds);

            var document = new RestaurantDocument(
                restaurant.Id,
                restaurant.Name,
                restaurant.PhoneNumber,
                restaurant.LocalityId,
                restaurant.State,
                restaurant.OpeningHour,
                restaurant.ClosingHour,
                restaurant.SubscriptionType,
                restaurant.ContractStatus,
                restaurant.ImageUrl,
                restaurant.Rating,
                restaurant.TotalRatingsCount,
                restaurant.ExpirationDate,
                restaurant.Description,
                restaurant.DescriptionEng,
                address: geographicLocation.Name,
                latitude: geographicLocation.Latitude,
                longitude: geographicLocation.Longitude
            );

            cuisines.ForEach(x => document.AddCuisine(x.ToRecord()));
            categories.ForEach(x => document.AddCategory(x.ToRecord()));


            await _documentCollection.RestaurantsCollection.InsertOneAsync(document, cancellationToken);
        }
    }
}
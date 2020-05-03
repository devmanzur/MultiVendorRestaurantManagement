using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
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
            var restaurant = await _tableDataProvider.GetRestaurantAsync(notification.PhoneNumber);

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
                restaurant.CategoryId,
                restaurant.ExpirationDate
            );

            await _documentCollection.RestaurantsCollection.InsertOneAsync(document, cancellationToken);
        }
    }
}
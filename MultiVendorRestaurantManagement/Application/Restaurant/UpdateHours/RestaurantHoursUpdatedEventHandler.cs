using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdateHours
{
    public class RestaurantHoursUpdatedEventHandler : INotificationHandler<RestaurantHoursUpdatedEvent>
    {
        private readonly DocumentCollection _collection;

        public RestaurantHoursUpdatedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(RestaurantHoursUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var restaurant = await _collection.RestaurantsCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (restaurant.HasValue())
            {
                restaurant.UpdateHours(notification.OpeningHour, notification.ClosingHour);
                await _collection.RestaurantsCollection.ReplaceOneAsync(Filter(notification), restaurant,
                    cancellationToken: cancellationToken);
            }
        }

        private static Expression<Func<RestaurantDocument, bool>> Filter(RestaurantHoursUpdatedEvent notification)
        {
            return x => x.RestaurantId == notification.RestaurantId;
        }
    }
}
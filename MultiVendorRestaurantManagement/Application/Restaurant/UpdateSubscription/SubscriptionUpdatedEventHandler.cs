using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdateSubscription
{
    public class SubscriptionUpdatedEventHandler : INotificationHandler<SubscriptionUpdatedEvent>
    {
        private readonly DocumentCollection _collection;

        public SubscriptionUpdatedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(SubscriptionUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var restaurant = await _collection.RestaurantsCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (restaurant.HasValue())
            {
                restaurant.UpdateSubscription(notification.SubscriptionType);
                await _collection.RestaurantsCollection.ReplaceOneAsync(Filter(notification), restaurant,
                    cancellationToken: cancellationToken);
            }
        }

        private static Expression<Func<RestaurantDocument, bool>> Filter(SubscriptionUpdatedEvent notification)
        {
            return x => x.RestaurantId == notification.RestaurantId;
        }
    }
}
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.GenericEvents
{
    public class FoodUpdatedEventHandler : INotificationHandler<FoodUpdatedEvent>
    {
        private readonly DocumentCollection _collection;

        public FoodUpdatedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(FoodUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var food = await _collection.FoodCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (food.HasValue())
            {
                if (notification.MenuUpdated())
                {
                    food.UpdateMenu(notification.MenuId);
                }

                await _collection.FoodCollection.ReplaceOneAsync(Filter(notification), food, cancellationToken: cancellationToken);
            }
        }

        private static Expression<Func<FoodDocument, bool>> Filter(FoodUpdatedEvent notification)
        {
            return x => x.FoodId == notification.FoodId;
        }
    }
}
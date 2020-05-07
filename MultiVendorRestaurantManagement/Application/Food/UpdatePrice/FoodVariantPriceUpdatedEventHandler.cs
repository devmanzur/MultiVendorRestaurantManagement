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

namespace MultiVendorRestaurantManagement.Application.Food.UpdatePrice
{
    public class FoodVariantPriceUpdatedEventHandler : INotificationHandler<FoodVariantPriceUpdatedEvent>
    {
        private readonly DocumentCollection _collection;

        public FoodVariantPriceUpdatedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(FoodVariantPriceUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var food = await _collection.FoodCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (food.HasValue())
            {
                notification.VariantPriceUpdates.ForEach(x => food.UpdateVariantPrice(x));
                await _collection.FoodCollection.ReplaceOneAsync(Filter(notification), food, cancellationToken: cancellationToken);
            }
            
        }

        private static Expression<Func<FoodDocument, bool>> Filter(FoodVariantPriceUpdatedEvent notification)
        {
            return x => x.FoodId == notification.FoodId;
        }
    }
}
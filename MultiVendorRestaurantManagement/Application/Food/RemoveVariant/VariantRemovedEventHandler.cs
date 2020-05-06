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

namespace MultiVendorRestaurantManagement.Application.Food.RemoveVariant
{
    public class VariantRemovedEventHandler : INotificationHandler<VariantRemovedEvent>
    {
        private readonly DocumentCollection _collection;

        public VariantRemovedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(VariantRemovedEvent notification, CancellationToken cancellationToken)
        {
            var food = await _collection.FoodCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (food.HasValue())
            {
                food.RemoveVariant(notification.VariantName);
                await _collection.FoodCollection.ReplaceOneAsync(Filter(notification), food,
                    cancellationToken: cancellationToken);
            }
        }

        private static Expression<Func<FoodDocument, bool>> Filter(VariantRemovedEvent notification)
        {
            return x => x.FoodId == notification.FoodId;
        }
    }
}
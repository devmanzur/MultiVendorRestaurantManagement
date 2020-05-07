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

namespace MultiVendorRestaurantManagement.Application.Food.RemoveAddOn
{
    public class AddOnRemovedEventHandler : INotificationHandler<AddOnRemovedEvent>
    {
        private readonly DocumentCollection _collection;

        public AddOnRemovedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }
        public async Task Handle(AddOnRemovedEvent notification, CancellationToken cancellationToken)
        {
            var food = await _collection.FoodCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (food.HasValue())
            {
                food.RemoveAddOn(notification.AddOnName);
                await _collection.FoodCollection.ReplaceOneAsync(Filter(notification), food,
                    cancellationToken: cancellationToken);
            }
        }
        
        private static Expression<Func<FoodDocument, bool>> Filter(AddOnRemovedEvent notification)
        {
            return x => x.FoodId == notification.FoodId;
        }
    }
}
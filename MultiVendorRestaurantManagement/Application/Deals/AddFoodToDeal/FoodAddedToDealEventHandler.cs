using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.Deals.AddFoodToDeal
{
    public class FoodAddedToDealEventHandler : INotificationHandler<FoodAddedToDealEvent>
    {
        private readonly DocumentCollection _collection;

        public FoodAddedToDealEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(FoodAddedToDealEvent notification, CancellationToken cancellationToken)
        {
            var food = await _collection.FoodCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (food.HasValue())
            {
                food.SetDeal(notification.DealId, notification.Description, notification.DescriptionEng,notification.EndDate);
                await _collection.FoodCollection.ReplaceOneAsync(Filter(notification), food,
                    cancellationToken: cancellationToken);
            }
        }

        private static Expression<Func<FoodDocument, bool>> Filter(FoodAddedToDealEvent notification)
        {
            return x => x.FoodId == notification.FoodId;
        }
    }
}
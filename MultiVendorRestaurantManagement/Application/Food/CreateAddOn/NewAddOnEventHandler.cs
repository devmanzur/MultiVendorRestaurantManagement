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

namespace MultiVendorRestaurantManagement.Application.Food.CreateAddOn
{
    public class NewAddOnEventHandler : INotificationHandler<NewAddOnEvent>
    {
        private readonly DocumentCollection _collection;

        public NewAddOnEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(NewAddOnEvent notification, CancellationToken cancellationToken)
        {
            var food = await _collection.FoodCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (food.HasValue())
            {
                food.NewAddOn(new AddOnDocument(notification.AddOnName, notification.AddOnNameEng,
                    notification.AddOnDescription, notification.AddOnDescriptionEng, notification.Price.Value));
                await _collection.FoodCollection.ReplaceOneAsync(Filter(notification), food,
                    cancellationToken: cancellationToken);
            }
        }

        private static Expression<Func<FoodDocument, bool>> Filter(NewAddOnEvent notification)
        {
            return x => x.FoodId == notification.FoodId;
        }
    }
}
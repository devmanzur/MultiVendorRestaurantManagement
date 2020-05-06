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

namespace MultiVendorRestaurantManagement.Application.Food.AddVariation
{
    public class NewVariantAddedEventHandler : INotificationHandler<NewVariantAddedEvent>
    {
        private readonly DocumentCollection _collection;

        public NewVariantAddedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(NewVariantAddedEvent notification, CancellationToken cancellationToken)
        {
            var food = await _collection.FoodCollection.Find(Filter(notification))
                .FirstOrDefaultAsync(cancellationToken);
            if (food.HasValue())
            {
                food.AddVariant(new VariantDocument(notification.VariantName, notification.VariantNameEng,
                    notification.Price));

                await _collection.FoodCollection.ReplaceOneAsync(Filter(notification), food, cancellationToken: cancellationToken);

            }
        }

        private static Expression<Func<FoodDocument, bool>> Filter(NewVariantAddedEvent notification)
        {
            return x => x.FoodId == notification.FoodId;
        }
    }
}
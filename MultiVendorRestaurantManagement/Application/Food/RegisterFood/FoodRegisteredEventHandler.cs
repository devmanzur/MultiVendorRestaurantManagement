using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.Food.RegisterFood
{
    public class FoodRegisteredEventHandler : INotificationHandler<FoodRegisteredEvent>
    {
        private readonly DocumentCollection _documentCollection;
        private readonly ITableDataProvider _tableDataProvider;

        public FoodRegisteredEventHandler(DocumentCollection documentCollection, ITableDataProvider tableDataProvider)
        {
            _documentCollection = documentCollection;
            _tableDataProvider = tableDataProvider;
        }

        public async Task Handle(FoodRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var item = await _tableDataProvider.GetFoodAsync(notification.RestaurantId, notification.FoodName);

            if (item.HasValue())
            {
                var food = new FoodDocument(item.RestaurantId,
                    notification.RestaurantName,
                    item.Id,
                    item.ImageUrl,
                    item.Name,
                    item.UnitPrice,
                    item.OldUnitPrice,
                    item.Type,
                    item.CategoryId,
                    notification.CategoryName,
                    item.Status,
                    item.IsGlutenFree,
                    item.IsVeg,
                    item.IsNonVeg
                );

                await _documentCollection.FoodCollection.InsertOneAsync(food, cancellationToken);
            }
        }
    }
}
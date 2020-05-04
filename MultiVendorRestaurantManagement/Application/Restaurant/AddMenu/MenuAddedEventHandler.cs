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

namespace MultiVendorRestaurantManagement.Application.Restaurant.AddMenu
{
    public class MenuAddedEventHandler : INotificationHandler<MenuAddedEvent>
    {
        private readonly DocumentCollection _collection;
        private readonly ITableDataProvider _tableDataProvider;

        public MenuAddedEventHandler(DocumentCollection collection, ITableDataProvider tableDataProvider)
        {
            _collection = collection;
            _tableDataProvider = tableDataProvider;
        }

        public async Task Handle(MenuAddedEvent notification, CancellationToken cancellationToken)
        {
            var menuData = await _tableDataProvider.GetMenuAsync(notification.MenuName);

            if (menuData.HasValue())
            {
                var restaurant = await _collection.RestaurantsCollection.Find(Filter(notification))
                    .FirstOrDefaultAsync(cancellationToken);
                if (restaurant.HasValue())
                {
                    restaurant.Menus.Add(new MenuRecord(menuData.Id, menuData.Name, menuData.NameEng));
                }

                await _collection.RestaurantsCollection.ReplaceOneAsync(Filter(notification), restaurant,
                    cancellationToken: cancellationToken);
            }
        }

        private static Expression<Func<RestaurantDocument, bool>> Filter(MenuAddedEvent notification)
        {
            return x => x.RestaurantId == notification.RestaurantId;
        }
    }
}
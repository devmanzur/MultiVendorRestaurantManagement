using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.City.RegisterCity
{
    public class CityRegisteredEventHandler : INotificationHandler<CityRegisteredEvent>
    {
        private readonly DocumentCollection _collection;
        private readonly ITableDataProvider _tableDataProvider;

        public CityRegisteredEventHandler(DocumentCollection collection, ITableDataProvider tableDataProvider)
        {
            _collection = collection;
            _tableDataProvider = tableDataProvider;
        }

        public async Task Handle(CityRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var city = await _tableDataProvider.GetCityAsync(notification.Name);


            if (city.HasValue())
                await _collection.CitiesCollection.InsertOneAsync(
                    new CityDocument(city.Id, city.Code, city.Name, city.NameEng),
                    cancellationToken);
        }
    }
}
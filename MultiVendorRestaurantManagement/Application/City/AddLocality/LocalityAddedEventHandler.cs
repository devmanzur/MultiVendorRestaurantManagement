using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.City.AddLocality
{
    public class LocalityAddedEventHandler : INotificationHandler<LocalityAddedEvent>
    {
        private readonly DocumentCollection _collection;
        private readonly ITableDataProvider _tableDataProvider;

        public LocalityAddedEventHandler(ITableDataProvider tableDataProvider, DocumentCollection collection)
        {
            _tableDataProvider = tableDataProvider;
            _collection = collection;
        }

        public async Task Handle(LocalityAddedEvent notification, CancellationToken cancellationToken)
        {
            var locality = await _tableDataProvider.GetLocalityAsync(notification.CityId, notification.LocalityName);

            if (locality.HasValue())
            {
                var record = await _collection.CitiesCollection.Find(x => x.CityId == notification.CityId)
                    .FirstOrDefaultAsync(cancellationToken);

                // ReSharper disable once PossibleNullReferenceException
                record.Localities.Add(new LocalityRecord(locality.Id, locality.Code, locality.Name, locality.NameEng));

                await _collection.CitiesCollection.ReplaceOneAsync(x => x.Id == record.Id, record,
                    cancellationToken: cancellationToken);
            }
        }
    }
}
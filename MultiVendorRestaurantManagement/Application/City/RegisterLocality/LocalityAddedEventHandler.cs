using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.Dapper;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.DbView;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.City.RegisterLocality
{
    public class LocalityAddedEventHandler : INotificationHandler<LocalityAddedEvent>
    {
        private readonly ITableDataProvider _tableDataProvider;
        private readonly DocumentCollection _collection;

        public LocalityAddedEventHandler(ITableDataProvider tableDataProvider, DocumentCollection collection)
        {
            _tableDataProvider = tableDataProvider;
            _collection = collection;
        }

        public async Task Handle(LocalityAddedEvent notification, CancellationToken cancellationToken)
        {
            var locality = await _tableDataProvider.GetLocalityDataAsync(notification.CityId, notification.LocalityName);

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
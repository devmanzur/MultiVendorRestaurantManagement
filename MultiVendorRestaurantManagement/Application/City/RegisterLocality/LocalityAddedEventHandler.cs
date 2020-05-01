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
using MultiVendorRestaurantManagement.DapperModel;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Application.City.RegisterLocality
{
    public class LocalityAddedEventHandler : INotificationHandler<LocalityAddedEvent>
    {
        private readonly string _connectionString;
        private readonly DocumentCollection _collection;

        public LocalityAddedEventHandler(IConfiguration configuration, DocumentCollection collection)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _collection = collection;
        }

        public async Task Handle(LocalityAddedEvent notification, CancellationToken cancellationToken)
        {
            var locality = await GetLocalityData(notification);

            if (locality.HasValue())
            {
                var record = await _collection.CityCollection.Find(x => x.CityId == notification.CityId)
                    .FirstOrDefaultAsync(cancellationToken);

                // ReSharper disable once PossibleNullReferenceException
                record.Localities.Add(new LocalityRecord(locality.Id, locality.Code, locality.Name, locality.NameEng));

                await _collection.CityCollection.ReplaceOneAsync(x => x.Id == record.Id, record,
                    cancellationToken: cancellationToken);
            }
        }

        private async Task<LocalityTableView> GetLocalityData(LocalityAddedEvent notification)
        {
            var sql = "SELECT * FROM Locality WHERE (Name = @Name AND CityId = @CityId)";
            await using var connection = new SqlConnection(_connectionString);
            var locality =
                await connection.QueryFirstOrDefaultAsync<LocalityTableView>(sql,
                    new {Name = notification.LocalityName, CityId = notification.CityId});
            return locality;
        }
    }
}
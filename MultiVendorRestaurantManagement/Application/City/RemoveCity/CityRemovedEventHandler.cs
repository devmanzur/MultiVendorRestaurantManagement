using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;

namespace MultiVendorRestaurantManagement.Application.City.RemoveCity
{
    public class CityRemovedEventHandler : INotificationHandler<CityRemovedEvent>
    {
        private readonly DocumentCollection _collection;

        public CityRemovedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(CityRemovedEvent notification, CancellationToken cancellationToken)
        {
            await _collection.CitiesCollection.DeleteOneAsync(x => x.CityId == notification.CityId, cancellationToken);
        }
    }
}
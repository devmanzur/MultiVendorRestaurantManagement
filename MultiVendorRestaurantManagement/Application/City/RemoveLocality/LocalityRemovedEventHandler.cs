using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using MediatR;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;

namespace MultiVendorRestaurantManagement.Application.City.RemoveLocality
{
    public class LocalityRemovedEventHandler : INotificationHandler<LocalityRemovedEvent>
    {
        private readonly DocumentCollection _collection;

        public LocalityRemovedEventHandler(DocumentCollection collection)
        {
            _collection = collection;
        }

        public async Task Handle(LocalityRemovedEvent notification, CancellationToken cancellationToken)
        {
            var city = await _collection.CitiesCollection.Find(x => x.CityId == notification.Id)
                .FirstOrDefaultAsync(cancellationToken);
            if (city.HasValue())
            {
                var locality = city.Localities.Find(x => x.LocalityId == notification.LocalityId);
                if (locality.HasValue())
                {
                    city.Localities.Remove(locality);
                    await _collection.CitiesCollection.ReplaceOneAsync(x => x.Id == city.Id, city,
                        cancellationToken: cancellationToken);
                }
            }
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultiVendorRestaurantManagement.Domain.Cities;

namespace MultiVendorRestaurantManagement.Application.City.RemoveCity
{
    public class CityRemovedEventHandler : INotificationHandler<CityRemovedEvent>
    {
        public Task Handle(CityRemovedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
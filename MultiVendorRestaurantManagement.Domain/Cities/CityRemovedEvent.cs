using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class CityRemovedEvent : DomainEventBase
    {
        public CityRemovedEvent(long cityId)
        {
            CityId = cityId;
        }

        public long CityId { get; }
    }
}
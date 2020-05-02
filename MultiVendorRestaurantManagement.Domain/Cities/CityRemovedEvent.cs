using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class CityRemovedEvent : DomainEventBase
    {
        public long CityId { get; }

        public CityRemovedEvent(long cityId)
        {
            CityId = cityId;
        }
    }
}
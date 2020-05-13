using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class LocalityAddedEvent : DomainEventBase
    {
        public LocalityAddedEvent(long cityId, string localityName)
        {
            CityId = cityId;
            LocalityName = localityName;
        }

        public long CityId { get; }
        public string LocalityName { get; }
    }
}
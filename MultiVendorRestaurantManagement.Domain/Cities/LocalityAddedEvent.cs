using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class LocalityAddedEvent : DomainEventBase
    {
        public long CityId { get; }
        public string LocalityName { get; }

        public LocalityAddedEvent(long cityId, string localityName)
        {
            CityId = cityId;
            LocalityName = localityName;
        }
    }
}
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class LocalityRemovedEvent : DomainEventBase
    {
        public LocalityRemovedEvent(long id, long localityId)
        {
            Id = id;
            LocalityId = localityId;
        }

        public long Id { get; }
        public long LocalityId { get; }
    }
}
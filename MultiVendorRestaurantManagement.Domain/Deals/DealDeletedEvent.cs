using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Deals
{
    public class DealDeletedEvent : DomainEventBase
    {
        public DealDeletedEvent(long id)
        {
            DealId = id;
        }

        public long DealId { get; }
    }
}
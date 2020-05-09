using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Deals
{
    public class DealDeletedEvent : DomainEventBase
    {
        public long DealId { get; }

        public DealDeletedEvent( long id)
        {
            DealId = id;
        }
    }
}
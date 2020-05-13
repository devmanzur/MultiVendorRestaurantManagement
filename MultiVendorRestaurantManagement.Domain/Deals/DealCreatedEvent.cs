using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Deals
{
    public class DealCreatedEvent : DomainEventBase
    {
        public DealCreatedEvent(string name)
        {
            DealName = name;
        }

        public string DealName { get; }
    }
}
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Deals
{
    public class DealCreatedEvent : DomainEventBase
    {
        public string DealName { get; }

        public DealCreatedEvent(string name)
        {
            DealName = name;
        }
    }
}
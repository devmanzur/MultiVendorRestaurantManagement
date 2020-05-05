using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class TagCreatedEvent  : DomainEventBase
    {
        public string Name { get; }

        public TagCreatedEvent(string name)
        {
            Name = name;
        }
    }
}
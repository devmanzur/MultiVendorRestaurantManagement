using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class TagDeletedEvent : DomainEventBase
    {
        public string Name { get; }

        public TagDeletedEvent(string name)
        {
            Name = name;
        }
    }
}
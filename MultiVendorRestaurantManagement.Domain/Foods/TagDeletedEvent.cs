using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class TagDeletedEvent : DomainEventBase
    {
        public TagDeletedEvent(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
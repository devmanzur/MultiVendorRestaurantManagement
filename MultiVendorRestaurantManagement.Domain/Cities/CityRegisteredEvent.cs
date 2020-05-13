using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class CityRegisteredEvent : DomainEventBase
    {
        public CityRegisteredEvent(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
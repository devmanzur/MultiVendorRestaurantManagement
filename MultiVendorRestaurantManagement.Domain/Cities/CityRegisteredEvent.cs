using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class CityRegisteredEvent : DomainEventBase
    {
        public string Name { get; }


        public CityRegisteredEvent( string name)
        {
            Name = name;
        }
    }
}
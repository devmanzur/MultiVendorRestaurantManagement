using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantRegisteredEvent : DomainEventBase
    {
        public string PhoneNumber { get; }

        public RestaurantRegisteredEvent(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
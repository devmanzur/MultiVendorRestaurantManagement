using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantRegisteredEvent : DomainEventBase
    {
        public RestaurantRegisteredEvent(string phoneNumber, string categoryName)
        {
            PhoneNumber = phoneNumber;
            CategoryName = categoryName;
        }

        public string PhoneNumber { get; }
        public string CategoryName { get; }
    }
}
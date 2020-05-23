using System.Collections.Generic;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantRegisteredEvent : DomainEventBase
    {
        public RestaurantRegisteredEvent(string phoneNumber, IEnumerable<long> categoryIds,
            IEnumerable<long> cuisineIds)
        {
            PhoneNumber = phoneNumber;
            CategoryIds = categoryIds;
            CuisineIds = cuisineIds;
        }

        public string PhoneNumber { get; }
        public IEnumerable<long> CategoryIds { get; }
        public IEnumerable<long> CuisineIds { get; }
    }
}
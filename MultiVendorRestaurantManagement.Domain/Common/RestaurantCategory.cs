using MultiVendorRestaurantManagement.Domain.Restaurants;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class RestaurantCategory
    {
        public long RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public Category Category { get; private set; }
        public long CategoryId { get; private set; }
    }
}
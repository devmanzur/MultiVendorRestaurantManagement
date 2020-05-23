using MultiVendorRestaurantManagement.Domain.Common;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantCategory
    {
        protected RestaurantCategory()
        {
            
        }
        public RestaurantCategory(Restaurant restaurant,  Categories.Category category)
        {
            Restaurant = restaurant;
            Category = category;
        }

        public long RestaurantId { get; private set; }
        public long CategoryId { get; private set; }
        public Categories.Category Category { get; private set; }
        public Restaurant Restaurant { get; private set; }
    }
}
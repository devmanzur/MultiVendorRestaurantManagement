using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Cuisines;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantCuisine
    {
        public long RestaurantId { get; private set; }
        public long CuisineId { get; private set; }
        public Cuisine Cuisine { get; private set; }
        public Restaurant Restaurant { get; private set; }

        protected RestaurantCuisine()
        {
            
        }
        
        public RestaurantCuisine(Restaurant restaurant, Cuisine cuisine)
        {
            Restaurant = restaurant;
            Cuisine = cuisine;
        }
    }
}
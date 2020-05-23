using System.Collections.Generic;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodRegisteredEvent : DomainEventBase
    {
        public FoodRegisteredEvent(long restaurantId, string restaurantName, string foodName, string categoryName,
            string menuName, string cuisineName, List<string> ingredients)
        {
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            FoodName = foodName;
            CategoryName = categoryName;
            MenuName = menuName;
            CuisineName = cuisineName;
            Ingredients = ingredients;
        }

        public long RestaurantId { get; }
        public string RestaurantName { get; }
        public string FoodName { get; }
        public string CategoryName { get; }
        public string MenuName { get; }
        public string CuisineName { get; }
        public List<string> Ingredients { get; }
    }
}
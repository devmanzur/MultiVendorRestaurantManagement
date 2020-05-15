using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodRegisteredEvent : DomainEventBase
    {
        public FoodRegisteredEvent(long restaurantId, string restaurantName, string foodName, string categoryName, string menuName)
        {
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            FoodName = foodName;
            CategoryName = categoryName;
            MenuName = menuName;
        }

        public long RestaurantId { get; }
        public string RestaurantName { get; }
        public string FoodName { get; }
        public string CategoryName { get; }
        public string MenuName { get; }
    }
}
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodRegisteredEvent : DomainEventBase
    {
        public long RestaurantId { get; }
        public string RestaurantName { get; }
        public string FoodName { get; }

        public FoodRegisteredEvent( long restaurantId,string restaurantName, string foodName)
        {
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            FoodName = foodName;
        }
    }
}
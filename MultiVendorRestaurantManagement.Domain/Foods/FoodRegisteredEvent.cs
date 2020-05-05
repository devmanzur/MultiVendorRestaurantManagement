using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodRegisteredEvent : DomainEventBase
    {
        public long RestaurantId { get; }
        public string FoodName { get; }

        public FoodRegisteredEvent( long restaurantId, string foodName)
        {
            RestaurantId = restaurantId;
            FoodName = foodName;
        }
    }
}
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class AddOnRemovedEvent : DomainEventBase
    {
        public AddOnRemovedEvent(long restaurantId, long foodId, string addOnName)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            AddOnName = addOnName;
        }

        public long RestaurantId { get; }
        public long FoodId { get; }
        public string AddOnName { get; }
    }
}
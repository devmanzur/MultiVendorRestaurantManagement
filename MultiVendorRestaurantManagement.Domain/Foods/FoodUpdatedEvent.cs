using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodUpdatedEvent : DomainEventBase
    {
        public long RestaurantId { get; }
        public long FoodId { get; }
        public long MenuId { get; }

        public FoodUpdatedEvent(long restaurantId, long foodId, long menuId)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            MenuId = menuId;
        }

        public bool MenuUpdated()
        {
            return MenuId != 0;
        }
    }
}
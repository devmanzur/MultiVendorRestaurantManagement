using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class MenuAddedEvent : DomainEventBase
    {
        public long RestaurantId { get; }
        public string MenuName { get; }
        public string MenuNameEng { get; }

        public MenuAddedEvent( long restaurantId, string menuName, string menuNameEng)
        {
            RestaurantId = restaurantId;
            MenuName = menuName;
            MenuNameEng = menuNameEng;
        }
    }
}
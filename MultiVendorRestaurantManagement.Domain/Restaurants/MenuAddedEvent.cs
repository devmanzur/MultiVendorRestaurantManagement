using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class MenuAddedEvent : DomainEventBase
    {
        private readonly string _imageUrl;
        public long RestaurantId { get; }
        public string MenuName { get; }
        public string MenuNameEng { get; }

        public MenuAddedEvent(long restaurantId,string menuName, string menuNameEng, string imageUrl)
        {
            _imageUrl = imageUrl;
            RestaurantId = restaurantId;
            MenuName = menuName;
            MenuNameEng = menuNameEng;
        }
    }
}
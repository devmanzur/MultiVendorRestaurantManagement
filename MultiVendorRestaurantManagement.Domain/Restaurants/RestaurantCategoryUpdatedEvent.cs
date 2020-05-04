using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantCategoryUpdatedEvent : DomainEventBase
    {
        public RestaurantCategoryUpdatedEvent(long restaurantId, long categoryId)
        {
            RestaurantId = restaurantId;
            CategoryId = categoryId;
        }

        public long RestaurantId { get; }
        public long CategoryId { get; }
    }
}
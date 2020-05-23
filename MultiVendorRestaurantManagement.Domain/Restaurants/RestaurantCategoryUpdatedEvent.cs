using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class RestaurantCategoryUpdatedEvent : DomainEventBase
    {
        public RestaurantCategoryUpdatedEvent(long restaurantId, long categoryId, string categoryName)
        {
            RestaurantId = restaurantId;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public long RestaurantId { get; }
        public long CategoryId { get; }
        public string CategoryName { get; }
    }
}
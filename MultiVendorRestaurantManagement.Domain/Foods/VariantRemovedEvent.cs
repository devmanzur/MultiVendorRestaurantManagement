using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class VariantRemovedEvent : DomainEventBase
    {
        public VariantRemovedEvent(long restaurantId, long foodId, string variantName)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            VariantName = variantName;
        }

        public long RestaurantId { get; }
        public long FoodId { get; }
        public string VariantName { get; }
    }
}
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

        public long RestaurantId { get; private set; }
        public long FoodId { get; private set; }
        public string VariantName { get; private set; }
    }
}
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class NewVariantAddedEvent : DomainEventBase
    {
        public long RestaurantId { get; }
        public long FoodId { get; }
        public string VariantName { get; }
        public string VariantNameEng { get; }
        public string VariantDescription { get; }
        public string VariantDescriptionEng { get; }
        public MoneyCustomValue Price { get; }

        public NewVariantAddedEvent(long restaurantId, long foodId, string variantName, string variantNameEng,
            MoneyCustomValue price, string varianDescription, string variantDescriptionEng)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            VariantName = variantName;
            VariantNameEng = variantNameEng;
            Price = price;
            VariantDescription = varianDescription;
            VariantDescriptionEng = variantDescriptionEng;
        }
    }
}
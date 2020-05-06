using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class NewVariantAddedEvent  : DomainEventBase
    {
        public long RestaurantId { get; }
        public long FoodId { get; }
        public string VariantName { get; }
        public string VariantNameEng { get; }
        public decimal Price { get; }

        public NewVariantAddedEvent(long restaurantId, long foodId, string variantName, string variantNameEng,  decimal price)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            VariantName = variantName;
            VariantNameEng = variantNameEng;
            Price = price;
        }

       
    }
}
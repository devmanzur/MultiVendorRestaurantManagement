using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class FoodPromotionIncludeModel : CustomValueObject
    {
        public FoodPromotionIncludeModel(long foodId, long restaurantId)
        {
            CheckRule(new ConditionMustBeTrueRule(foodId.HasValue() && restaurantId.HasValue(),
                "food and restaurant value for promotional models are invalid"));
            FoodId = foodId;
            RestaurantId = restaurantId;
        }

        public long FoodId { get; protected set; }
        public long RestaurantId { get; protected set; }
    }
}
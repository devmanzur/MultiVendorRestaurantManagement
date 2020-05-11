using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class FixedDiscountModel : CustomValueObject
    {
        public FixedDiscountModel(decimal discountAmount, decimal minBillAmount, int minQuantity)
        {
            CheckRule(new ConditionMustBeTrueRule(HelperFunctions.ValidAmount(DiscountAmount) &&
                                                  HelperFunctions.ValidAmount(MinBillAmount) &&
                                                  HelperFunctions.ValidCount(MinQuantity),
                "invalid parameters for discount"));
            DiscountAmount = discountAmount;
            MinBillAmount = minBillAmount;
            MinQuantity = minQuantity;
        }

        public int MaxQuantity = 1000;
        public decimal DiscountAmount { get; private set; }
        public int MinQuantity { get; private set; }
        public decimal MinBillAmount { get; private set; }
    }
}
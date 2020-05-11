using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class PercentageDiscountModel : CustomValueObject
    {
        public PercentageDiscountModel(decimal discountPercentage, decimal maxDiscountAmount, decimal minBillAmount,
            int minQuantity)
        {
            CheckRule(new ConditionMustBeTrueRule(HelperFunctions.ValidAmount(DiscountPercentage)
                                                  && HelperFunctions.ValidAmount(maxDiscountAmount) &&
                                                  HelperFunctions.ValidAmount(MinBillAmount) &&
                                                  HelperFunctions.ValidCount(MinQuantity),
                "invalid parameters for discount"));
            DiscountPercentage = discountPercentage;
            MaxDiscountAmount = maxDiscountAmount;
            MinBillAmount = minBillAmount;
            MinQuantity = minQuantity;
        }

        public int MaxQuantity = 1000;
        public decimal DiscountPercentage { get; private set; }
        public decimal MaxDiscountAmount { get; private set; }
        public int MinQuantity { get; private set; }
        public decimal MinBillAmount { get; private set; }
    }
}
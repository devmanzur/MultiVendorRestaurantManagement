using Common.Invariants;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class FixedDiscountModel : CustomValueObject
    {
        public int MaxQuantity = 1000;

        public FixedDiscountModel(decimal discountAmount, decimal minBillAmount, int minQuantity)
        {
            CheckRule(new ConditionMustBeTrueRule(HelperFunctions.ValidAmount(DiscountAmount) &&
                                                  HelperFunctions.ValidAmount(MinBillAmount) &&
                                                  HelperFunctions.ValidCount(MinQuantity),
                "invalid parameters for discount"));
            DiscountAmount = discountAmount;
            MinBillAmount = minBillAmount;
            MinQuantity = minQuantity;
            Type = OfferType.FixedDiscount;
        }
        public OfferType Type { get;  }

        public decimal DiscountAmount { get; }
        public int MinQuantity { get; }
        public decimal MinBillAmount { get; }
    }
}
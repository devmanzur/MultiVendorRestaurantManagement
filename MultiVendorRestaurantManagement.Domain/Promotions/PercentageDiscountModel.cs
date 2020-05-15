using Common.Invariants;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class PercentageDiscountModel : CustomValueObject
    {
        public int MaxQuantity = 1000;

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
            Type = OfferType.PackageDiscount;
        }

        public OfferType Type { get; }

        public decimal DiscountPercentage { get; }
        public decimal MaxDiscountAmount { get; }
        public int MinQuantity { get; }
        public decimal MinBillAmount { get; }
    }
}
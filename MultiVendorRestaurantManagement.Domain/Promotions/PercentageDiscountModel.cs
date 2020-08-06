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

        public OfferType Type { get; protected set; }

        public decimal DiscountPercentage { get; protected set; }
        public decimal MaxDiscountAmount { get; protected set; }
        public int MinQuantity { get; protected set; }
        public decimal MinBillAmount { get; protected set; }
    }
}
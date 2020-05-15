using Common.Invariants;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Deals
{
    public class PackageDiscountModel : CustomValueObject
    {
        public PackageDiscountModel(int packageSize, int freeItemQuantityInPackage)
        {
            CheckRule(new ConditionMustBeTrueRule(
                HelperFunctions.ValidCount(packageSize) && HelperFunctions.ValidCount(freeItemQuantityInPackage) &&
                packageSize > freeItemQuantityInPackage, "invalid conditions for package deal"));
            PackageSize = packageSize;
            FreeItemQuantityInPackage = freeItemQuantityInPackage;
            Type = OfferType.PackageDiscount;
        }

        public OfferType Type { get;  }

        public int PackageSize { get; }
        public int FreeItemQuantityInPackage { get; }
    }
}
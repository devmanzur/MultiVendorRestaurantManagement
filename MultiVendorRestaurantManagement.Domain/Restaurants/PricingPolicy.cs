using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class PricingPolicy : Entity
    {
        public decimal MinimumCharge { get; protected set; }
        public decimal MaximumCharge { get; protected set; }
        public decimal FixedCharge { get; protected set; }
        public int MaxItemCountInFixedPrice { get; protected set; }
        public decimal AdditionalPrice { get; protected set; }

        public PricingPolicy(decimal minimumCharge, decimal maximumCharge, decimal fixedCharge,
            int maxItemCountInFixedPrice, decimal additionalPrice)
        {
            MinimumCharge = minimumCharge;
            MaximumCharge = maximumCharge;
            FixedCharge = fixedCharge;
            MaxItemCountInFixedPrice = maxItemCountInFixedPrice;
            AdditionalPrice = additionalPrice;
        }
    }
}
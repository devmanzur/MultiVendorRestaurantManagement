using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Restaurants;

namespace MultiVendorRestaurantManagement.Domain.Rules
{
    public class PricingPolicyMustBeValidRule : IBusinessRule
    {
        private readonly PricingPolicy _policy;

        public PricingPolicyMustBeValidRule(PricingPolicy policy)
        {
            _policy = policy;
        }

        public bool IsBroken()
        {
            if (_policy.HasNoValue()) return true;
            if (_policy.MinimumCharge <= 0) return true;
            if (_policy.FixedCharge > 0 && _policy.MaxItemCountInFixedPrice == 0) return true;
            if (!HelperFunctions.ValidAmount(_policy.MaximumCharge)
                || !HelperFunctions.ValidAmount(_policy.AdditionalPrice)
                || !HelperFunctions.ValidAmount(_policy.FixedCharge)
                || !HelperFunctions.ValidAmount(_policy.MinimumCharge)
                || !HelperFunctions.ValidCount(_policy.MaxItemCountInFixedPrice)
            ) return true;

            return false;
        }

        public string Message { get; } = "Invalid pricing policy";
    }
}
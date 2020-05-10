namespace MultiVendorRestaurantManagement.ApiContract.Request
{
    public class UpdatePricingPolicyRequest
    {
        public decimal MinimumCharge { get;  set; }
        public decimal MaximumCharge { get;  set; }
        public decimal FixedCharge { get;  set; }
        public int MaxItemCountInFixedPrice { get;  set; }
        public decimal AdditionalPricePerUnit { get;  set; }
    }
}
using MultiVendorRestaurantManagement.Domain.Rules;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class VariantPriceUpdateModel 
    {
        public VariantPriceUpdateModel(string variantName, decimal price)
        {
            VariantName = variantName;
            NewPrice = price;
        }

        public string VariantName { get; protected set; }
        public decimal NewPrice { get; protected set; }
    }
}
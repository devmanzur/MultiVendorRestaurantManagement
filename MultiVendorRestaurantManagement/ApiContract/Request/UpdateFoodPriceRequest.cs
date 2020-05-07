using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.ApiContract.Request
{
    public class UpdateFoodPriceRequest
    {
        public List<VariantPriceUpdateDto> VariantPrices { get; set; }
    }

    public class VariantPriceUpdateDto
    {
        public string VariantName { get; set; }
        public decimal NewPrice { get; set; }
    }
}
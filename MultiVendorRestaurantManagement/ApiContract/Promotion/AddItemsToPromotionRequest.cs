using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.ApiContract.Promotion
{
    public class AddItemsToPromotionRequest
    {
        public List<long> FoodIds { get; set; }
    }
}
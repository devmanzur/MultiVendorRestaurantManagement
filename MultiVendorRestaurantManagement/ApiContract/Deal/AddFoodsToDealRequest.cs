using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.ApiContract.Deal
{
    public class AddFoodsToDealRequest
    {
        public List<FoodPromotionDto> Models { get; set; }
    }

    public class FoodPromotionDto
    {
        public long FoodId { get; set; }
        public long RestaurantId { get; set; }
    }
}
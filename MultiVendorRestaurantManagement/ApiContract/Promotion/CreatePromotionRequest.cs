using System;

namespace MultiVendorRestaurantManagement.ApiContract.Promotion
{
    public class CreatePromotionRequest
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string DescriptionEng { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MinimumBillAmount { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public int MinimumQuantity { get; set; } = 1;

        public bool IsFixedPriceDiscount { get; set; } = false;

        public decimal DiscountPercentage { get; set; } = 0;
        public decimal MaximumDiscount { get; set; } = 0;

    }
}
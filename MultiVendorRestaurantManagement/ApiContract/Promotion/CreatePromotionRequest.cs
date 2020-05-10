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
        public decimal MinimumBillAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinimumQuantity { get; set; }

        public bool IsFixedPriceDiscount { get; set; }
        
        public decimal DiscountPercentage { get; set; }
        public decimal MaximumDiscount { get; set; }

    }
}
using System;

namespace MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData
{
    public class DealTableData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionEng { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFixedDiscount { get; set; }
        public decimal FixedDiscountAmount { get; set; }
        public bool IsPackageDeal { get; set; }
        public int PackageSize { get; set; }
        public int FreeItemQuantityInPackage { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal MaximumDiscountAmount { get; set; }
        public int MinimumItemQuantity { get; set; }
        public decimal MinimumBillAmount { get; set; }
    }
}
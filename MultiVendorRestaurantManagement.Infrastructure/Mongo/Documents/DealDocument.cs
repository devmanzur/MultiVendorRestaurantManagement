using System;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Domain.Promotions;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class DealDocument : BaseDocument
    {
        public DealDocument(long dealId, string name, string description, string descriptionEng, string imageUrl,
            DateTime startDate, DateTime endDate, bool isFixedDiscount, bool isPackageDeal)
        {
            DealId = dealId;
            Name = name;
            Description = description;
            DescriptionEng = descriptionEng;
            ImageUrl = imageUrl;
            StartDate = startDate;
            EndDate = endDate;
            IsFixedDiscount = isFixedDiscount;
            IsPackageDeal = isPackageDeal;
        }

        public long DealId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string DescriptionEng { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsFixedDiscount { get; private set; }
        public bool IsPackageDeal { get; private set; }
       
        public PackageDiscountModel PackageDetail { get; private set; }
        public PercentageDiscountModel PercentageDetail { get; private set; }
        public FixedDiscountModel FixedDetail { get; private set; }
        public void CreatePackageDiscount(int size, int freeCount)
        {
            IsPackageDeal = true;
            PackageDetail = new PackageDiscountModel(size, freeCount);
        }
        
        public void CreateFixedDiscount(decimal discountAmount, decimal minBillAmount, int minQuantity)
        {
            IsFixedDiscount = true;
            FixedDetail = new FixedDiscountModel(discountAmount, minBillAmount, minQuantity);
        }
        
        public void CreatePercentageDeal(decimal percentage, decimal maxDiscountAmount, decimal minBillAmount,
            int minQuantity)
        {
            PercentageDetail = new PercentageDiscountModel(percentage, maxDiscountAmount, minBillAmount, minQuantity);
        }
    }
}
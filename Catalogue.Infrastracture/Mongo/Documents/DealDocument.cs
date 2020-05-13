using System;
using Catalogue.Infrastructure.Mongo.Documents;

namespace Catalogue.Infrastracture.Mongo.Documents
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

        public long DealId { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string DescriptionEng { get; protected set; }
        public string ImageUrl { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public bool IsFixedDiscount { get; protected set; }
        public bool IsPackageDeal { get; protected set; }

        public PackageDiscountModel PackageDetail { get; private set; }
        public PercentageDiscountModel PercentageDetail { get; private set; }
        public FixedDiscountModel FixedDetail { get; private set; }
    }
}
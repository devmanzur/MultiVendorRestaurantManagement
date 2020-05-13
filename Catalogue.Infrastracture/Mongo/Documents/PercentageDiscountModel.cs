namespace Catalogue.Infrastructure.Mongo.Documents
{
    public class PercentageDiscountModel
    {
        public int MaxQuantity = 1000;

        public PercentageDiscountModel(decimal discountPercentage, decimal maxDiscountAmount, decimal minBillAmount,
            int minQuantity)
        {
            DiscountPercentage = discountPercentage;
            MaxDiscountAmount = maxDiscountAmount;
            MinBillAmount = minBillAmount;
            MinQuantity = minQuantity;
        }

        public decimal DiscountPercentage { get; protected set; }
        public decimal MaxDiscountAmount { get; protected set; }
        public int MinQuantity { get; protected set; }
        public decimal MinBillAmount { get; protected set; }
    }
}
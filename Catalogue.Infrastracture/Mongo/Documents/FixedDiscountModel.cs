namespace Catalogue.Infrastracture.Mongo.Documents
{
    public class FixedDiscountModel
    {
        public int MaxQuantity = 1000;

        public FixedDiscountModel(decimal discountAmount, decimal minBillAmount, int minQuantity)
        {
            DiscountAmount = discountAmount;
            MinBillAmount = minBillAmount;
            MinQuantity = minQuantity;
        }

        public decimal DiscountAmount { get; protected set; }
        public int MinQuantity { get; protected set; }
        public decimal MinBillAmount { get; protected set; }
    }
}
namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodTag
    {
        public long FoodId { get; set; }
        public Food Food { get; set; }
        public long TagId { get; private set; }
        public Tag Tag { get; set; }
    }
}
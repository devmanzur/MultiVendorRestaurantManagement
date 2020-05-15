namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodTag
    {
        public long FoodId { get; protected set; }
        public Food Food { get; protected set;}
        public long TagId { get; private set; }
        public Tag Tag { get;protected set; }
    }
}
using MultiVendorRestaurantManagement.Domain.Foods;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class FoodCategory
    {
        public long FoodId { get; private set; }
        public Food Food { get; private set; }
        public Category Category { get; private set; }
        public long CategoryId { get; private set; }
    }
}
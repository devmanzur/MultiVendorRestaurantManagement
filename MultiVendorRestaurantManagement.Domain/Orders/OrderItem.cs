using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Orders
{
    public class OrderItem : Entity
    {
        public OrderItem(int quantity, decimal price, long foodId, string foodName)
        {
            Quantity = quantity;
            Price = price;
            FoodId = foodId;
            FoodName = foodName;
        }

        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public long FoodId { get; private set; }
        public string FoodName { get; private set; }
        
    }
}
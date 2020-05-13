using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Orders
{
    public class OrderItem : Entity
    {
        public OrderItem(int quantity, decimal total, long foodId, string foodName, decimal discount)
        {
            Quantity = quantity;
            Total = total;
            FoodId = foodId;
            FoodName = foodName;
            Discount = discount;
        }

        public virtual Order Order { get; private set; }
        public int Quantity { get; }
        public decimal Total { get; }
        public long FoodId { get; }
        public string FoodName { get; }

        public decimal Discount { get; }
    }
}
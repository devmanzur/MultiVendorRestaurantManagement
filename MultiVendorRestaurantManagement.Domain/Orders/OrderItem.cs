using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

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
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public long FoodId { get; private set; }
        public string FoodName { get; private set; }

        public decimal Discount { get; private set; }
        
    }
}
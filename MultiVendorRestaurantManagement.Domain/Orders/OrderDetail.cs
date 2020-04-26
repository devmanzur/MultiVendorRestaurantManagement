using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Orders
{
    
    public class OrderDetail : Entity{
        public string Address { get; set; }
        public string Flat { get; set; }
        public string HouseNo { get; set; }
        public LocationValue DeliveryLocation { get; set; }  
        public string ContactNumber { get; set; }
        public string CustomerName { get; set; }
    }
}
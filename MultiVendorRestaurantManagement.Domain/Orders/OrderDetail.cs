using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Orders
{
    
    public class OrderDetail : Entity{
        public OrderDetail(LocationCustomValue deliveryLocationCustom, string address, string flat, string houseNo, string contactNumber, string customerName)
        {
            DeliveryLocationCustom = deliveryLocationCustom;
            Address = address;
            Flat = flat;
            HouseNo = houseNo;
            ContactNumber = contactNumber;
            CustomerName = customerName;
        }

        public string Address { get; protected set; }
        public string Flat { get; protected set; }
        public string HouseNo { get; protected set; }
        public LocationCustomValue DeliveryLocationCustom { get; protected set; }  
        public string ContactNumber { get; protected set; }
        public string CustomerName { get; protected set; }
    }
}
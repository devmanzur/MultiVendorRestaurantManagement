using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.City
{
    public class Area : Entity
    {
        public Area(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public int Code { get; protected set; }
        public string Name { get; protected set; }
    }
}
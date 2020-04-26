using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Tag  : Entity
    {
        public Tag(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
    }
}
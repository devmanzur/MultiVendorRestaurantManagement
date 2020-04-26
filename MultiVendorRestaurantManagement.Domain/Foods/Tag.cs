using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Tag  : Entity
    {
        public Tag(string name, string nameEng)
        {
            Name = name;
            NameEng = nameEng;
        }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
    }
}
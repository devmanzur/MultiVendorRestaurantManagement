using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class AddOn : Entity
    {
        public AddOn(string name, string nameEng, string description, string descriptionEng, MoneyCustomValue price)
        {
            Name = name;
            NameEng = nameEng;
            Description = description;
            DescriptionEng = descriptionEng;
            Price = price;
        }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public string Description { get; protected set; }
        public string DescriptionEng { get; protected set; }
        public MoneyCustomValue Price { get; set; }
        public virtual Food Food { get; private set; }
    }
}
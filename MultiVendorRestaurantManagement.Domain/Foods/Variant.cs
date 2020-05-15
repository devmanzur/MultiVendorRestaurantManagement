using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Variant : Entity
    {
        public Variant()
        {
        }

        public Variant(string name, string nameEng, MoneyValue price, string description, string descriptionEng)
        {
            Name = name;
            NameEng = nameEng;
            Price = price;
            OldPrice = price;
            Description = description;
            DescriptionEng = descriptionEng;
        }

        public string Name { get;protected set; }
        public string NameEng { get;protected set; }
        public string Description { get; protected set;}
        public string DescriptionEng { get;protected set; }
        public MoneyValue Price { get; private set; }
        public MoneyValue OldPrice { get; private set; }
        public Food Food { get; private set; }


        public void UpdatePrice(MoneyValue value)
        {
            OldPrice = Price;
            Price = value;
        }

        public bool IsPriceReduced()
        {
            return OldPrice.Value > Price.Value;
        }
    }
}
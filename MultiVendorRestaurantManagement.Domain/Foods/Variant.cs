using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Variant : Entity
    {
        public Variant()
        {
            
        }
        public Variant(string name, string nameEng, MoneyCustomValue price, string description, string descriptionEng)
        {
            Name = name;
            NameEng = nameEng;
            Price = price;
            OldPrice = price;
            Description = description;
            DescriptionEng = descriptionEng;
        }

        public string Name { get; private set; }
        public string NameEng { get; private set; }
        public string Description { get; private set; }
        public string DescriptionEng { get; private set; }
        public MoneyCustomValue Price { get; private set; }
        public MoneyCustomValue OldPrice { get; private set; }
        public Food Food { get; private set; }


        public void UpdatePrice(MoneyCustomValue customValue)
        {
            OldPrice = Price;
            Price = customValue;
        }

        public bool IsPriceReduced()
        {
            return OldPrice.Value > Price.Value;
        }
    }
}
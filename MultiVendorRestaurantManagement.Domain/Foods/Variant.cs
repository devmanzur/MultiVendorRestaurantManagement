using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Variant : Entity
    {
        public Variant(string name, string nameEng, MoneyValue price, Food food)
        {
            Name = name;
            NameEng = nameEng;
            Price = price;
            Food = food;
        }

        public string Name { get; private set; }
        public string NameEng { get; private set; }
        public MoneyValue Price { get; private set; }
        public Food Food { get; protected set; }
    }
}
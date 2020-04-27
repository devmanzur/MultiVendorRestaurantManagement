using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class FoodCategory : AggregateRoot
    {
        public FoodCategory(string name, string nameEng, string imageUrl)
        {
            Name = name;
            NameEng = nameEng;
            ImageUrl = imageUrl;
        }

        public string ImageUrl { get; protected set; }
        public string Name { get; private set; }
        public string NameEng { get; private set; }

    }
}
using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class Category : AggregateRoot
    {
        public Category(string name, string nameEng, string imageUrl, CategoryTypeOf typeOf)
        {
            Name = name;
            NameEng = nameEng;
            ImageUrl = imageUrl;
            TypeOf = typeOf;
        }

        public string ImageUrl { get; protected set; }
        public string Name { get; private set; }
        public string NameEng { get; private set; }

        public CategoryTypeOf TypeOf { get; protected set; }
    }
}
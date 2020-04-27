using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class RestaurantCategory: AggregateRoot
    {
        public RestaurantCategory(string name, string nameEng, string imageUrl)
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
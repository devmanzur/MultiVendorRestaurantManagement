using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Category
{
    public class CategoryUpdatedEvent : DomainEventBase
    {
        public CategoryUpdatedEvent(long categoryId, string name, string nameEng, string imageUrl)
        {
            CategoryId = categoryId;
            Name = name;
            NameEng = nameEng;
            ImageUrl = imageUrl;
        }

        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string ImageUrl { get; }
    }
}
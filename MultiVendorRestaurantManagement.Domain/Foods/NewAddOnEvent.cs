using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class NewAddOnEvent : DomainEventBase
    {
        public NewAddOnEvent(long restaurantId, long foodId, string addOnName, string addOnNameEng,
            string addOnDescription, string addOnDescriptionEng, MoneyValue price)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            AddOnName = addOnName;
            AddOnNameEng = addOnNameEng;
            AddOnDescription = addOnDescription;
            AddOnDescriptionEng = addOnDescriptionEng;
            Price = price;
        }

        public long RestaurantId { get; }
        public long FoodId { get; }
        public string AddOnName { get; }
        public string AddOnNameEng { get; }
        public string AddOnDescription { get; }
        public string AddOnDescriptionEng { get; }
        public MoneyValue Price { get; }
    }
}
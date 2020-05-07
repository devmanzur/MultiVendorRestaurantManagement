using System.Collections.Generic;
using System.Linq;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodUpdatedEvent : DomainEventBase
    {
        public long RestaurantId { get; }
        public long FoodId { get; }
        public long MenuId { get; }

        public List<VariantPriceUpdateModel> VariantPriceUpdates { get; }

        public FoodUpdatedEvent(long restaurantId, long foodId, List<VariantPriceUpdateModel> variantPriceUpdates)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            VariantPriceUpdates = variantPriceUpdates;
        }

        public FoodUpdatedEvent(long restaurantId, long foodId, long menuId)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            MenuId = menuId;
        }

        public bool MenuUpdated()
        {
            return MenuId != 0;
        }

        public bool PriceUpdated()
        {
            return VariantPriceUpdates.HasValue() && VariantPriceUpdates.Any();
        }
    }
}
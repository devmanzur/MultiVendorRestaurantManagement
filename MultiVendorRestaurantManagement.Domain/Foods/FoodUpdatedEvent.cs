using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodUpdatedEvent : DomainEventBase
    {
        public FoodUpdatedEvent(long restaurantId, long foodId, List<VariantPriceUpdateModel> variantPriceUpdates,
            bool isDiscounted)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            VariantPriceUpdates = variantPriceUpdates;
            IsDiscounted = isDiscounted;
        }

        public FoodUpdatedEvent(long restaurantId, long foodId, long menuId, string menuName)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            MenuId = menuId;
            MenuName = menuName;
        }

        public FoodUpdatedEvent(long restaurantId, long foodId, FoodStatus status = FoodStatus.Invalid)
        {
            RestaurantId = restaurantId;
            FoodId = foodId;
            Status = status;
        }

        public long RestaurantId { get; }
        public long FoodId { get; }
        public FoodStatus Status { get; }
        public long MenuId { get; }
        public string MenuName { get; }

        public List<VariantPriceUpdateModel> VariantPriceUpdates { get; }
        public bool IsDiscounted { get; }

        public bool MenuWasUpdated()
        {
            return MenuId != 0;
        }

        public bool StatusWasUpdated()
        {
            return Status != FoodStatus.Invalid;
        }

        public bool PriceWasUpdated()
        {
            return VariantPriceUpdates.HasValue() && VariantPriceUpdates.Any();
        }
    }
}
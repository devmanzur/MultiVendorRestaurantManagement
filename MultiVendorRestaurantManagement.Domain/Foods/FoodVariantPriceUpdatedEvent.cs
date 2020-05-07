using System.Collections.Generic;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class FoodVariantPriceUpdatedEvent : DomainEventBase
    {
        public long FoodId { get; }
        public List<VariantPriceUpdateModel> VariantPriceUpdates { get; }

        public FoodVariantPriceUpdatedEvent(long foodId, List<VariantPriceUpdateModel> variantPriceUpdates)
        {
            FoodId = foodId;
            VariantPriceUpdates = variantPriceUpdates;
        }
    }
}
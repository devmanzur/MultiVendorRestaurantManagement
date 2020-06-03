using BasketManagement.Common.Utils;
using BasketManagement.Domain.Base;
using BasketManagement.Domain.Extensions;

namespace BasketManagement.Domain.Baskets
{
    public class BasketItem : Entity
    {
        public BasketItem( long foodId, string foodName, string imageUrl,  decimal unitPrice,  int quantity)
        {
            CheckRule(new ConditionMustBeTrueRule(
                foodId.IsValidId() &&
                foodName.HasValue() &&
                imageUrl.HasValue() &&
                unitPrice.IsValidAmount() &&
                quantity.IsValidQuantity(),
                "invalid parameters passed for basket item"
                ));
            
            FoodId = foodId;
            FoodName = foodName;
            ImageUrl = imageUrl;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public long FoodId { get; private set; }
        public string FoodName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public string ImageUrl { get; private set; }


        public void Increase()
        {
            Quantity++;
        }
        
    }
}
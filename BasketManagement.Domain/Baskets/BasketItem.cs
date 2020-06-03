using BasketManagement.Domain.Base;

namespace BasketManagement.Domain.Baskets
{
    public class BasketItem : Entity
    {
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
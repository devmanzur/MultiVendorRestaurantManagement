using System.ComponentModel.DataAnnotations;

namespace BasketManagement.ApiContract.Request
{
    public class AddBasketItemRequest
    {

        public string UserId { get; set; }
        public string SessionId { get; set; }
        public long FoodId { get; set; }
        
        public string FoodName { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public string ImageUrl { get; set; }
    }
}
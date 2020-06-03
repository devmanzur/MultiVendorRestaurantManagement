namespace BasketManagement.ApiContract.Request
{
    public class RemoveBasketItemRequest
    {
        public long FoodId { get; set; }
        public int Quantity { get; set; }

    }
}
namespace BasketManagement.ApiContract.Request
{
    public class ClearBasketRequest
    {
        public string UserId { get; set; }
        public string SessionId { get; set; }
    }
}
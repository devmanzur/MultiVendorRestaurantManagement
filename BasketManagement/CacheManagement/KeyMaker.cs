namespace BasketManagement.CacheManagement
{
    public class KeyMaker
    {
        private const string BasketKey = "BasketManagement.Common.Utils.basket_owner";
        
        public static string GetBasketKey(string userId, string sessionId)
        {
            return sessionId + BasketKey + userId;
        }
    }
}
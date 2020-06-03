namespace BasketManagement.Domain.Extensions
{
    public static class PrimitiveExtensions
    {

        public static bool IsValidAmount(this decimal amount)
        {
            return amount > 0;
        }
         public static bool IsValidId(this long id)
        {
            return id > 0;
        } 
         public static bool IsValidQuantity(this int quantity)
        {
            return quantity > 0;
        }
        
    }
}
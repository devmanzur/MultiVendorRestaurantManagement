namespace Common.Invariants
{
    public enum SubscriptionType
    {
        Monthly,
        Yearly,
        BiYearly,
        SalesCommission,
        Invalid
    }

    public class SubscriptionHelper
    {
        public static SubscriptionType ConvertToSubscription(string item)
        {
            if (string.IsNullOrEmpty(item)) return SubscriptionType.Invalid;
            
            return item.ToLowerInvariant() switch
            {
                "monthly" => SubscriptionType.Monthly,
                "yearly" => SubscriptionType.Yearly,
                "biyearly" => SubscriptionType.BiYearly,
                "salescomission" => SubscriptionType.SalesCommission,
                _ => SubscriptionType.Invalid
            };
        }
    }
}
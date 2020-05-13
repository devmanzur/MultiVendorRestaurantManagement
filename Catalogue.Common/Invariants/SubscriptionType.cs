using System;

namespace Catalogue.Common.Invariants
{
    public enum SubscriptionType
    {
        Monthly,
        Yearly,
        BiYearly,
        SalesCommission,
        Invalid
    }

    public static class SubscriptionHelper
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

        public static DateTime GetExpirationTime(this SubscriptionType type)
        {
            return type switch
            {
                SubscriptionType.Monthly => DateTime.Now.AddMonths(1),
                SubscriptionType.Yearly => DateTime.Now.AddMonths(12),
                SubscriptionType.BiYearly => DateTime.Now.AddMonths(6),
                _ => DateTime.Now
            };
        }
    }
}
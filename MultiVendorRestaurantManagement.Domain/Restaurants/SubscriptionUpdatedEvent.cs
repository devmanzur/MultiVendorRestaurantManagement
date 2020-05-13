using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class SubscriptionUpdatedEvent : DomainEventBase
    {
        public SubscriptionUpdatedEvent(long restaurantId, SubscriptionType subscriptionType)
        {
            RestaurantId = restaurantId;
            SubscriptionType = subscriptionType;
        }

        public long RestaurantId { get; }
        public SubscriptionType SubscriptionType { get; }
    }
}
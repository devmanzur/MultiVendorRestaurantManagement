using System;

namespace MultiVendorRestaurantManagement.Domain.Base
{
    public class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            this.OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}
using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.Domain.Base
{
    public abstract class AggregateRoot : Entity
    {
        private List<IDomainEvent> _domainEvents;


        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();


        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public abstract IDomainEvent GetAddedDomainEvent();
        public abstract IDomainEvent GetRemovedDomainEvent();
    }
}
using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.Domain.Base
{
    public class AggregateRoot : Entity
    {
        private List<IDomainEvent> _domainEvents;

      
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= new List<IDomainEvent>();
            this._domainEvents.Add(domainEvent);
        }
        
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
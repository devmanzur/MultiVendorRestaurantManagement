using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

#pragma warning disable 618

namespace MultiVendorRestaurantManagement.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext _context;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(
            IDomainEventsDispatcher domainEventsDispatcher, RestaurantContext context)
        {
            _domainEventsDispatcher = domainEventsDispatcher;
            _context = context;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            var changes = _context.ChangeTracker
                .Entries<AggregateRoot>()
                .Where(x =>
                    HasDomainEvents(x) || HasBeenAddedOrRemoved(x)
                ).ToList();
            
            AddEventsForAddedOrRemovedEntities(changes);
            
            var changesMade = await _context.SaveChangesAsync(cancellationToken);
            if (changesMade > 0) await _domainEventsDispatcher.DispatchEventsFor(changes);
            return changesMade;
        }

        private static void AddEventsForAddedOrRemovedEntities(List<EntityEntry<AggregateRoot>> changes)
        {
            var addedOrRemovedEntities = changes.Where(HasBeenAddedOrRemoved).ToList();

            foreach (var change in addedOrRemovedEntities)
            {
                switch (change.State)
                {
                    case EntityState.Added:
                        change.Entity.AddDomainEvent(change.Entity.GetAddedDomainEvent());
                        break;
                    case EntityState.Deleted:
                        change.Entity.AddDomainEvent(change.Entity.GetRemovedDomainEvent());
                        break;
                }
            }
        }


        private static bool HasDomainEvents(EntityEntry<AggregateRoot> x)
        {
            return x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any();
        }

        private static bool HasBeenAddedOrRemoved(EntityEntry<AggregateRoot> x)
        {
            return x.State == EntityState.Added || x.State == EntityState.Deleted;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Infrastructure.Domain
{
    public class DomainEventDispatcher : IDomainEventsDispatcher
    {
        private readonly RestaurantContext _context;
        private readonly IMediator _mediator;

        public DomainEventDispatcher(RestaurantContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task DispatchEventsFor(List<EntityEntry<AggregateRoot>> changes)
        {
            var domainEvents = changes
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            ClearRecords(changes);

            var tasks = domainEvents
                .Select(async (domainEvent) => { await _mediator.Publish(domainEvent); });
            await Task.WhenAll(tasks);
        }

        private static void ClearRecords(List<EntityEntry<AggregateRoot>> changes)
        {
            changes
                .ForEach(entity =>
                {
                    entity.Entity.ClearDomainEvents();
                    entity.State = EntityState.Detached;
                });
        }
    }
}
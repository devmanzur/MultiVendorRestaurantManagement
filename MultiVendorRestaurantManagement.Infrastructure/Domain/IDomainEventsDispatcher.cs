using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Infrastructure.Domain
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsFor(List<EntityEntry<AggregateRoot>> changes);
    }
}
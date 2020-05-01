using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            var changesMade = await _context.SaveChangesAsync(cancellationToken);
            if (changesMade > 0) await _domainEventsDispatcher.DispatchEventsAsync();
            return changesMade;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;
using MultiVendorRestaurantManagement.Infrastructure.Mongo;

namespace MultiVendorRestaurantManagement.Infrastructure
{
    public static class DependencySetup
    {
        public static void SetupInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RestaurantContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainEventsDispatcher, DomainEventDispatcher>();
            services.AddScoped<DocumentCollection>();

        }
    }
}
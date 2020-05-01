using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiVendorRestaurantManagement.Infrastructure.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Infrastructure
{
    public static class DependencySetup
    {
        public static void SetupInfrastructure(this IServiceCollection services, string connnectionString)
        {
            services.AddDbContext<RestaurantContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(connnectionString);
            });
            services.AddScoped<IContext, RestaurantContext>();
        }
    }
}
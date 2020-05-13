using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastructure.Mongo;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogue.Infrastracture
{
    public static class DependencySetup
    {
        public static void SetupInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<DocumentCollection>();
        }
    }
}
using Catalogue.Infrastracture.Elastic;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastructure.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogue.Infrastracture
{
    public static class DependencySetup
    {
        public static void SetupInfrastructure(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddScoped<DocumentCollection>();
            services.AddElasticSearch(configuration);
            services.AddScoped<IElasticSearchService, ElasticSearchService>();
        }
    }
}
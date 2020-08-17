using System;
using Catalogue.Infrastracture.Mongo.Documents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace Catalogue.Infrastracture.Elastic
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ElasticSearch:Server"];
            var defaultIndex = configuration["ElasticSearch:Index"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex);

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);

            services.AddSingleton(client);

            CreateIndex(client, defaultIndex);
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.DefaultMappingFor<FoodDocument>(m => m
                .Ignore(p => p.UnitPrice)
                .Ignore(p => p.OldUnitPrice)
                .Ignore(p => p.TotalRatingCount)
                .Ignore(p => p.TotalOrderCount)
                .Ignore(p => p.Rating)
            );
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<FoodDocument>(x => x.AutoMap())
            );
        }
    }
}
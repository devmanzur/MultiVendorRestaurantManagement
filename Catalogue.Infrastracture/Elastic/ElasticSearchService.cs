using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Infrastracture.Mongo.Documents;
using Nest;

namespace Catalogue.Infrastracture.Elastic
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly ElasticClient _elasticClient;

        public ElasticSearchService(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public Task<object> Find(string query)
        {
            throw new System.NotImplementedException();
        }

        public async Task Insert(List<RestaurantDocument> documents)
        {
            var result = await _elasticClient.IndexManyAsync(documents, "restaurant");
        }
    }
}
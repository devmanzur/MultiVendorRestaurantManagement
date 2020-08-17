using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Infrastracture.Mongo.Documents;

namespace Catalogue.Infrastracture.Elastic
{
    public interface IElasticSearchService
    {
        Task<object> Find(string query);

        Task Insert(List<RestaurantDocument> restaurantDocuments);
    }
}
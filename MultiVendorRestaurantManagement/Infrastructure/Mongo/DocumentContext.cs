using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo
{

    enum Collections
    {
        Restaurants
    }
    
    public class DocumentContext
    {
        private readonly IMongoDatabase _documents;

        public DocumentContext(IConfiguration configuration)
        {
            var connectivity = configuration.GetValue<MongoConnectivityConfiguration>("MongoConnection");
            var client = new MongoClient(connectivity.ConnectionString);
            _documents = client.GetDatabase(connectivity.Database);
        }
        
        public IMongoCollection<RestaurantDocument> ActiveInformation 
            => _documents.GetCollection<RestaurantDocument>(Collections.Restaurants.ToString());
    }
}
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo
{
    internal enum Collections
    {
        Restaurants,
        Cities,
        RestaurantCategories
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
        
        public IMongoCollection<RestaurantDocument> Restaurants 
            => _documents.GetCollection<RestaurantDocument>(Collections.Restaurants.ToString());
        public IMongoCollection<CityDocument> Cities 
            => _documents.GetCollection<CityDocument>(Collections.Cities.ToString());
        public IMongoCollection<RestaurantCategoryDocument> RestaurantCategories 
            => _documents.GetCollection<RestaurantCategoryDocument>(Collections.RestaurantCategories.ToString());
    }
}
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo
{
    internal enum Collections
    {
        Restaurants,
        Cities,
        Categories
    }
    
    public class DocumentCollection
    {
        private readonly IMongoDatabase _documents;

        public DocumentCollection(IConfiguration configuration)
        {
            var connectivity = configuration.GetSection("MongoConnection").Get<MongoConnectivityConfiguration>();
            var client = new MongoClient(connectivity.ConnectionString);
            _documents = client.GetDatabase(connectivity.Database);
        }
        
        public IMongoCollection<RestaurantDocument> RestaurantsCollection 
            => _documents.GetCollection<RestaurantDocument>(Collections.Restaurants.ToString());
        public IMongoCollection<CityDocument> CitiesCollection 
            => _documents.GetCollection<CityDocument>(Collections.Cities.ToString());
        public IMongoCollection<RestaurantCategoryDocument> CategoriesCollection
            => _documents.GetCollection<RestaurantCategoryDocument>(Collections.Categories.ToString());
    }
}
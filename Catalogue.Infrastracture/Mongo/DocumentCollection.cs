using Catalogue.Infrastracture.Mongo.Documents;
using Catalogue.Infrastructure.Mongo;
using Catalogue.Infrastructure.Mongo.Documents;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalogue.Infrastracture.Mongo
{
    internal enum Collections
    {
        Restaurants,
        Cities,
        Categories,
        Foods,
        Deals
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

        public IMongoCollection<FoodDocument> FoodCollection
            => _documents.GetCollection<FoodDocument>(Collections.Foods.ToString());

        public IMongoCollection<DealDocument> DealCollection
            => _documents.GetCollection<DealDocument>(Collections.Deals.ToString());

        public IMongoCollection<CityDocument> CitiesCollection
            => _documents.GetCollection<CityDocument>(Collections.Cities.ToString());

        public IMongoCollection<CategoryDocument> CategoriesCollection
            => _documents.GetCollection<CategoryDocument>(Collections.Categories.ToString());
    }
}
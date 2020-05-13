using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogue.Infrastracture.Mongo.Documents
{
    public abstract class BaseDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
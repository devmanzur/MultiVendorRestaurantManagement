using Catalogue.Common.Invariants;
using MongoDB.Bson;

namespace Catalogue.Infrastracture.Mongo.Documents
{
    public class PreferenceDocument : BsonDocument
    {
        
        public string Username { get; private set; }
        public string PreferredLanguage { get; private set; }


        public void SetLanguageCode(SupportedLanguageCode code)
        {
            PreferredLanguage = code.ToDescriptionString();
        }
        
    }
}
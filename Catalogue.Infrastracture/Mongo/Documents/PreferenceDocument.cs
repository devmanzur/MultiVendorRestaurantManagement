using Catalogue.Common.Invariants;
using MongoDB.Bson;

namespace Catalogue.Infrastracture.Mongo.Documents
{
    public class PreferenceDocument : BsonDocument
    {

        public PreferenceDocument(string username, SupportedLanguageCode code)
        {
            Username = username;
            PreferredLanguage = code.ToDescriptionString();
        }
        
        public string Username { get; private set; }
        public string PreferredLanguage { get; private set; }


        public void SetPreferredLanguage(SupportedLanguageCode code)
        {
            PreferredLanguage = code.ToDescriptionString();
        }
        
    }
}
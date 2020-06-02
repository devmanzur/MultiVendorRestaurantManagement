using System.Threading.Tasks;
using Catalogue.Common.Invariants;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using MongoDB.Driver;

namespace MessengerBotAPI.Services
{
    public interface IUserPreferenceService
    {
        Task<PreferenceDocument> GetUserPreference(string username);
    }

    public class UserPreferenceService : IUserPreferenceService
    {
        private IMongoCollection<PreferenceDocument> _userPreferences;

        public UserPreferenceService( DocumentCollection collection)
        {
            _userPreferences = collection.UserPreferences;

        }
        
        public async Task<PreferenceDocument> GetUserPreference(string username)
        {
            var pref = await _userPreferences.Find(x => x.Username == username).FirstOrDefaultAsync();
            if (pref.HasNoValue())
            {
                pref = await CreateNew(username);
            }

            return pref;
        }

        private async Task<PreferenceDocument> CreateNew(string username)
        {
            PreferenceDocument pref;
            pref = new PreferenceDocument(username, SupportedLanguageCode.English);
            await _userPreferences.InsertOneAsync(pref);
            return pref;
        }
    }
}
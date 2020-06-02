using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.Common.Invariants;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using Catalogue.Infrastracture.Mongo.Documents;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;

namespace MessengerBotAPI.Application.ChangeLanguage
{
    public class ChangeLanguageCommandHandler : IRequestHandler<ChangeLanguageCommand, Result<string>>
    {
        private readonly DocumentCollection _collection;
        public IDistributedCache Cache { get; }
        private const string LanguageKey = "language";

        private string[] SupportedLanguages = new[]
        {
            "english",
            "inglese",
            "italiano",
            "italian"
        };

        public ChangeLanguageCommandHandler(IDistributedCache cache, DocumentCollection collection)
        {
            _collection = collection;
            Cache = cache;
        }

        public async Task<Result<string>> Handle(ChangeLanguageCommand request, CancellationToken cancellationToken)
        {
            var language = request.QueryResult.Parameters.Fields.FirstOrDefault(x => x.Key == LanguageKey).Value
                .StringValue;

            if (!SupportedLanguages.Contains(language))
                return Result.Failure<string>("sorry we only support italian and english");

            await SetUserLocalizationPreference(request.Username, GetLanguageCode(language), cancellationToken);

            return Result.Ok("");
        }

        private async Task<Result> SetUserLocalizationPreference(string username, SupportedLanguageCode languageCode,
            CancellationToken cancellationToken)
        {
            var pref = await _collection.UserPreferences.Find(x => x.Username == username)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (pref.HasValue())
            {
                pref.SetPreferredLanguage(languageCode);
                await _collection.UserPreferences.ReplaceOneAsync(x => x.Username == username, pref,
                    cancellationToken: cancellationToken);
                return Result.Ok();
            }

            await _collection.UserPreferences.InsertOneAsync(new PreferenceDocument(username, languageCode),
                cancellationToken: cancellationToken);
            return Result.Ok();
        }

        private SupportedLanguageCode GetLanguageCode(string language)
        {
            if (language == "english" || language == "inglese") return SupportedLanguageCode.English;
            if (language == "italian" || language == "italiano") return SupportedLanguageCode.Italian;

            return SupportedLanguageCode.English;
        }
    }
}
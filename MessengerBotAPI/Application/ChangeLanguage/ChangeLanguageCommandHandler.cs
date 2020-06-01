using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.Common.Utils;
using Catalogue.Infrastracture.Mongo;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

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

            SetUserLocalizationPreference(request.Username, GetLanguageCode(language));

            return Result.Ok("");
        }

        private void SetUserLocalizationPreference(string username, object languageCode)
        {
           
        }

        private object GetLanguageCode(string language)
        {
            if (language == "english" || language == "inglese") return "en";
            if (language == "italian" || language == "italiano") return "it";

            return "en";
        }
    }
}
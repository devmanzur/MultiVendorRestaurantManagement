using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;
using MessengerBotAPI.ApiContract;

namespace MessengerBotAPI.Application.ChangeLanguage
{
    public class ChangeLanguageCommand : IRequest<Result<string>>
    {
        public QueryResult QueryResult { get; }
        public string SessionId { get; }

        public ChangeLanguageCommand(QueryResult queryResult, DetectTextIntentRequest request)
        {
            QueryResult = queryResult;
            SessionId = request.SessionId;
            Username = request.Username;
        }

        public string Username { get;  }
    }
}
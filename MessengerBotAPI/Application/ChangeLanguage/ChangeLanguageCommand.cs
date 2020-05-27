using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;

namespace MessengerBotAPI.Application.ChangeLanguage
{
    public class ChangeLanguageCommand : IRequest<Result<object>>
    {
        public ChangeLanguageCommand(QueryResult queryResult)
        {
            throw new System.NotImplementedException();
        }
    }
}
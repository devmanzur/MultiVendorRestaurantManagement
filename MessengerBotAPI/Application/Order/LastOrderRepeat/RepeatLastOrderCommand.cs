using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;
using MessengerBotAPI.ApiContract;

namespace MessengerBotAPI.Application.Order.LastOrderRepeat
{
    public class RepeatLastOrderCommand : IRequest<Result<object>>
    {
        public RepeatLastOrderCommand(QueryResult queryResult, DetectTextIntentRequest requestSessionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
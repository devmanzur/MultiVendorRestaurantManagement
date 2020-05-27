using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;

namespace MessengerBotAPI.Application.Order.LastOrderRepeat
{
    public class RepeatLastOrderCommand : IRequest<Result<object>>
    {
        public RepeatLastOrderCommand(QueryResult queryResult)
        {
            throw new System.NotImplementedException();
        }
    }
}
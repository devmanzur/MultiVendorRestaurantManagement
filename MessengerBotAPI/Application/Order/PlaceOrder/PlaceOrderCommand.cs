using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;
using MessengerBotAPI.ApiContract;

namespace MessengerBotAPI.Application.Order.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<Result<object>>
    {
        public PlaceOrderCommand(QueryResult queryResult, DetectTextIntentRequest requestSessionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
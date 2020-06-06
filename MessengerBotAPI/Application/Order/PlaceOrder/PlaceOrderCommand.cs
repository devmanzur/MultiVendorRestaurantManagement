using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;
using MessengerBotAPI.ApiContract;

namespace MessengerBotAPI.Application.Order.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<Result<object>>
    {
        public QueryResult QueryResult { get; }
        public DetectTextIntentRequest Request { get; }

        public PlaceOrderCommand(QueryResult queryResult, DetectTextIntentRequest request)
        {
            QueryResult = queryResult;
            Request = request;
        }
    }
}
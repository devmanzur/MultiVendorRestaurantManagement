using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;
using MessengerBotAPI.ApiContract;

namespace MessengerBotAPI.Application.Order.AddToCart
{
    public class AddFoodToCartCommand :  IRequest<Result<object>>
    {
        public QueryResult QueryResult { get; }
        public DetectTextIntentRequest Request { get; }

        public AddFoodToCartCommand(QueryResult queryResult, DetectTextIntentRequest request)
        {
            QueryResult = queryResult;
            Request = request;
        }
    }
}
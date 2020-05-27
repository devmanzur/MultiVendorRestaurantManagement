using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;

namespace MessengerBotAPI.Application.Order.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<Result<object>>
    {
        public PlaceOrderCommand(QueryResult queryResult)
        {
            throw new System.NotImplementedException();
        }
    }
}
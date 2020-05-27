using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;

namespace MessengerBotAPI.Application.Order.AddToCart
{
    public class AddFoodToCartCommand :  IRequest<Result<object>>
    {
        public AddFoodToCartCommand(QueryResult queryResult)
        {
            throw new System.NotImplementedException();
        }
    }
}
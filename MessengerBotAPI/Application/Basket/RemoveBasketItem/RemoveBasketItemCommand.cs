using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MediatR;

namespace MessengerBotAPI.Application.Basket.RemoveBasketItem
{
    public class RemoveBasketItemCommand: IRequest<Result<int>>
    {
        public RemoveBasketItemCommand(QueryResult queryResult)
        {
            
        }
    }
}
using Catalogue.Base;
using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract;

namespace MessengerBotAPI.Application.Basket.GetBasketInformation
{
    public class GetBasketInformationQuery : IQuery<Result<object>>
    {
        public GetBasketInformationQuery(QueryResult queryResult, DetectTextIntentRequest requestSessionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
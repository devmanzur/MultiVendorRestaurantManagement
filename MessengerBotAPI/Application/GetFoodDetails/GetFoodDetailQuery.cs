using Catalogue.Base;
using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract;

namespace MessengerBotAPI.Application.GetFoodDetails
{
    public class GetFoodDetailQuery : IQuery<Result<object>>
    {
        public GetFoodDetailQuery(QueryResult queryResult, DetectTextIntentRequest requestSessionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
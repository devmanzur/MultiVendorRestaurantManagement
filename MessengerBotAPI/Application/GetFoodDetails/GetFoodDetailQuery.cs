using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract;
using MessengerBotAPI.Application.Base;

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
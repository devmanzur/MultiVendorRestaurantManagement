using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract;
using MessengerBotAPI.Application.Base;

namespace MessengerBotAPI.Application.GetDeliveryStatus
{
    public class GetDeliveryStatusQuery : IQuery<Result<object>>
    {
        public GetDeliveryStatusQuery(QueryResult queryResult, DetectTextIntentRequest requestSessionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
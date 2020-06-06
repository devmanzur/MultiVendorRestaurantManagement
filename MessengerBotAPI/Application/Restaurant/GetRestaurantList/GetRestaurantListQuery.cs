using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract;
using MessengerBotAPI.ApiContract.Pagination;
using MessengerBotAPI.ApiContract.Response;
using MessengerBotAPI.Application.Base;

namespace MessengerBotAPI.Application.Restaurant.GetRestaurantList
{
    public class GetRestaurantListQuery : IQuery<Result<IPagedList<RestaurantMinimalDto>>>
    {
        public QueryResult QueryResult { get; }

        public GetRestaurantListQuery(QueryResult queryResult, DetectTextIntentRequest requestSessionId)
        {
            QueryResult = queryResult;
        }
    }
}
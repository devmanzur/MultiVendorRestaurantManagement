using Catalogue.ApiContract.Response;
using Catalogue.Base;
using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract.Pagination;

namespace MessengerBotAPI.Application.Restaurant.GetRestaurantList
{
    public class GetRestaurantListQuery : IQuery<Result<IPagedList<RestaurantMinimalDto>>>
    {
        public QueryResult QueryResult { get; }

        public GetRestaurantListQuery(QueryResult queryResult)
        {
            QueryResult = queryResult;
        }
    }
}
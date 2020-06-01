using System.Collections.Generic;
using Catalogue.Base;
using Catalogue.Infrastracture.Mongo.Documents;
using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract;

namespace MessengerBotAPI.Application.Restaurant.GetMenu
{
    public class GetRestaurantMenuQuery : IQuery<Result<List<MenuRecord>>>
    {
        public QueryResult QueryResult { get; }

        public GetRestaurantMenuQuery(QueryResult queryResult, DetectTextIntentRequest requestSessionId)
        {
            QueryResult = queryResult;
        }
    }
}
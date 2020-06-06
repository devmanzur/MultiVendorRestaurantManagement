using System.Collections.Generic;
using Catalogue.Infrastracture.Mongo.Documents;
using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract;
using MessengerBotAPI.Application.Base;

namespace MessengerBotAPI.Application.Restaurant.GetCategoryMenu
{
    public class GetCategoryMenuQuery : IQuery<Result<List<MenuRecord>>>
    {
        public QueryResult QueryResult { get; }

        public GetCategoryMenuQuery(QueryResult queryResult, DetectTextIntentRequest requestSessionId)
        {
            QueryResult = queryResult;
        }
    }
}
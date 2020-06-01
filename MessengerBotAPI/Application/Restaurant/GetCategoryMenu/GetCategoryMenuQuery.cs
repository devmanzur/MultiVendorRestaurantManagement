using System.Collections.Generic;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using Catalogue.Infrastracture.Mongo.Documents;
using CSharpFunctionalExtensions;
using Google.Cloud.Dialogflow.V2;
using MessengerBotAPI.ApiContract;
using MessengerBotAPI.ApiContract.Pagination;

namespace MessengerBotAPI.Application.GetCategoryMenu
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
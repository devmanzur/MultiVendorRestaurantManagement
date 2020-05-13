using System;
using System.Linq.Expressions;
using Catalogue.Infrastracture.Mongo.Documents;
using MongoDB.Driver;

namespace Catalogue.Utils
{
    public class Filters
    {
        public static FilterDefinition<T> EmptyFilter<T>() where T : BaseDocument
        {
            return Builders<T>.Filter.Empty;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Catalogue.Common.Invariants;
using Catalogue.Common.Utils;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogue.Infrastracture.Mongo.Documents
{
    public class RestaurantDocument : BaseDocument
    {
        

        public string Description { get;protected set; }
        public string DescriptionEng { get;protected set; }
        public long RestaurantId { get; protected set; }
        public string Name { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public long LocalityId { get; protected set; }
        public string State { get; protected set; }
        public int OpeningHour { get; protected set; }
        public int ClosingHour { get; protected set; }
        public string SubscriptionType { get; protected set; }
        public string ContractStatus { get; protected set; }
        public string ImageUrl { get; protected set; }
        public double Rating { get; protected set; }
        public int TotalRatingsCount { get; protected set; }
        public List<MenuRecord> Menus { get; protected set;}
        public List<string> Categories { get; protected set;}
        public List<string> Cuisines { get; protected set;}
        public long ManagerId { get; protected set; }
        public long PricingPolicyId { get; protected set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ExpirationDate { get; private set; }

        public string GetState()
        {
            if (State.Equals(RestaurantState.Open.ToString()))
            {
                var currentHour = DateTime.Now.Hour;
                if (currentHour < OpeningHour || currentHour > ClosingHour) return RestaurantState.Closed.ToString();
            }

            return State;
        }

        public static Expression<Func<RestaurantDocument, object>> GetOrderBy(string orderBy)
        {
            if (orderBy.HasNoValue()) return x => x.Id;
            return orderBy.ToLowerInvariant() switch
            {
                "name" => x => x.Name,
                "id" => x => x.RestaurantId,
                "locality" => x => x.LocalityId,
                "state" => x => x.State,
                "subscription" => x => x.SubscriptionType,
                _ => x => x.Id
            };
        }
    }

    public class MenuRecord
    {
        public MenuRecord(long menuId, string name, string nameEng, string imageUrl)
        {
            MenuId = menuId;
            Name = name;
            NameEng = nameEng;
            ImageUrl = imageUrl;
        }

        public long MenuId { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public string ImageUrl { get; protected set; }
    }
}
using System;
using System.Collections.Generic;
using Catalogue.Common.Invariants;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogue.Infrastracture.Mongo.Documents
{
    public class RestaurantDocument : BaseDocument
    {
        public RestaurantDocument(long restaurantId, string name, string phoneNumber, long localityId, string state,
            int openingHour, int closingHour, string subscriptionType, string contractStatus, string imageUrl,
            double rating, int totalRatingsCount, long categoryId, DateTime expirationDate)
        {
            RestaurantId = restaurantId;
            Name = name;
            PhoneNumber = phoneNumber;
            LocalityId = localityId;
            State = state;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            SubscriptionType = subscriptionType;
            ContractStatus = contractStatus;
            ImageUrl = imageUrl;
            Rating = rating;
            TotalRatingsCount = totalRatingsCount;
            CategoryId = categoryId;
            ExpirationDate = expirationDate;
            Menus = new List<MenuRecord>();
        }

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
        public List<MenuRecord> Menus { get; protected set; }
        public long ManagerId { get; set; }
        public long PricingPolicyId { get; set; }
        public long CategoryId { get; protected set;}

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ExpirationDate { get; protected set; }

        public string GetState()
        {
            if (State.Equals(RestaurantState.Open.ToString()))
            {
                var currentHour = DateTime.Now.Hour;
                if (currentHour < OpeningHour || currentHour > ClosingHour) return RestaurantState.Closed.ToString();
            }

            return State;
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
using System;
using System.Collections.Generic;
using Common.Invariants;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class RestaurantDocument : BaseDocument
    {
        public RestaurantDocument(long restaurantId, string name, string phoneNumber, long localityId, string state,
            int openingHour, int closingHour, string subscriptionType, string contractStatus, string imageUrl,
            double rating, int totalRatingsCount, DateTime expirationDate, string description, string descriptionEng)
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
            ExpirationDate = expirationDate;
            Description = description;
            DescriptionEng = descriptionEng;
            Menus = new List<MenuRecord>();
            Cuisines = new List<CuisineRecord>();
            Categories = new List<CategoryRecord>();
        }
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
        public List<CategoryRecord> Categories { get; protected set;}
        public List<CuisineRecord> Cuisines { get; protected set;}
        public long ManagerId { get; protected set; }
        public long PricingPolicyId { get; protected set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ExpirationDate { get; private set; }

        public void UpdateHours(in int openingHour, in int closingHour)
        {
            OpeningHour = openingHour;
            ClosingHour = closingHour;
        }

        public void UpdateSubscription(SubscriptionType subscription)
        {
            SubscriptionType = subscription.ToString();
            ExpirationDate = subscription.GetExpirationTime();
        }

        public void AddMenu(MenuRecord menu)
        {
            Menus.Add(menu);
        }

        public void AddCategory(CategoryRecord category)
        {
            Categories.Add(category);
        }
        public void RemoveCategory(CategoryRecord category)
        {
            Categories.Remove(category);
        } 
        public void AddCuisine(CuisineRecord cuisine)
        {
            Cuisines.Add(cuisine);
        }
        public void RemoveCuisine(CuisineRecord cuisine)
        {
            Cuisines.Remove(cuisine);
        }
    }

    public class CategoryRecord
    {
        public string Name { get; set; }
        public string NameEng { get; set; }
        public long Id { get; set; }
    }

    public class CuisineRecord
    {
        public string Name { get; set; }
        public string NameEng { get; set; }
        public long Id { get; set; }
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
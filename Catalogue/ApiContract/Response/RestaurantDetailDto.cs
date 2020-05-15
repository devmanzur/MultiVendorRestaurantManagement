using System;
using System.Collections.Generic;
using Catalogue.Infrastracture.Mongo.Documents;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogue.ApiContract.Response
{
    public class RestaurantDetailDto
    {
        public RestaurantDetailDto(long restaurantId, string name, string description, string descriptionEng,
            string phoneNumber, long localityId, string state, int openingHour, int closingHour, string imageUrl,
            double rating, int totalRatingsCount, long categoryId, string categoryName)
        {
            RestaurantId = restaurantId;
            Name = name;
            Description = description;
            DescriptionEng = descriptionEng;
            PhoneNumber = phoneNumber;
            LocalityId = localityId;
            State = state;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            ImageUrl = imageUrl;
            Rating = rating;
            TotalRatingsCount = totalRatingsCount;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public long RestaurantId { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string DescriptionEng { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public long LocalityId { get; protected set; }
        public string State { get; protected set; }
        public int OpeningHour { get; protected set; }
        public int ClosingHour { get; protected set; }
        public string ImageUrl { get; protected set; }
        public double Rating { get; protected set; }
        public int TotalRatingsCount { get; protected set; }
        public long CategoryId { get; protected set; }
        public string CategoryName { get; set; }

        public List<MenuDetailDto> Menus { get; protected set; }


        public void SetMenuDetail(List<MenuDetailDto> menus)
        {
            Menus = menus;
        }
    }

    public class MenuDetailDto
    {
        public MenuDetailDto(MenuRecord menu, List<FoodMinimalDto> foods)
        {
            MenuId = menu.MenuId;
            Name = menu.Name;
            NameEng = menu.NameEng;
            ImageUrl = menu.ImageUrl;
            Foods = foods;
        }

        public long MenuId { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public string ImageUrl { get; protected set; }
        public List<FoodMinimalDto> Foods { get; private set; }
    }
}
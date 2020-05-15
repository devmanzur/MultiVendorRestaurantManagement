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

        public long RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionEng { get; set; }
        public string PhoneNumber { get; set; }
        public long LocalityId { get; set; }
        public string State { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
        public int TotalRatingsCount { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<MenuDetailDto> Menus { get; set; }


        public void SetMenuDetail(List<MenuDetailDto> menus)
        {
            Menus = menus;
        }
    }

    public class MenuDetailDto
    {
        public MenuDetailDto(long menuId, string menuName, string menuNameEng, string imageUrl,
            List<FoodMinimalDto> foods)
        {
            MenuId = menuId;
            Name = menuName;
            NameEng = menuNameEng;
            ImageUrl = imageUrl;
            Foods = foods;
        }

        public long MenuId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string ImageUrl { get; set; }
        public List<FoodMinimalDto> Foods { get; set; }
    }
}
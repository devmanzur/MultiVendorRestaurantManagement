using System.Collections.Generic;

namespace Catalogue.ApiContract.Response
{
    public class FoodMinimalDto
    {
        public FoodMinimalDto(long foodId, string foodName, long restaurantId, string restaurantName,
            long categoryId, string categoryName, double rating, decimal basePrice,
            decimal currentPrice, string priceTag, long dealId, string dealDescription)
        {
            FoodId = foodId;
            FoodName = foodName;
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            Rating = rating;
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
            PriceTag = priceTag;
            DealId = dealId;
            DealDescription = dealDescription;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public long FoodId { get; set; }
        public long RestaurantId { get; set; }
        public string FoodName { get; set; }
        public string RestaurantName { get; set; }
        public double Rating { get; set; }
        public long DealId { get; set; }
        public string DealDescription { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string PriceTag { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}
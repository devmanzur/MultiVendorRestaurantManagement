using System.Collections.Generic;

namespace Catalogue.ApiContract.Response
{
    public class FoodMinimalDto
    {
        public long FoodId { get; set; }
        public long RestaurantId { get; set; }
        public string FoodName { get; set; }
        public string RestaurantName { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public long DealId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string PriceTag { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}
using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.ApiContract.Food
{
    public class RegisterFoodRequest
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Type { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsVeg { get; set; }
        public bool IsNonVeg { get; set; }
        public long CategoryId { get; set; }
        public long CuisineId { get; set; }
        public long MenuId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string DescriptionEng { get; set; }

        public List<string> Ingredients { get; set; }
    }
}
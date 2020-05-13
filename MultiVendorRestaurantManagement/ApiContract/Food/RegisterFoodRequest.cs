namespace MultiVendorRestaurantManagement.ApiContract.Request
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
        public string ImageUrl { get; set; }
    }
}
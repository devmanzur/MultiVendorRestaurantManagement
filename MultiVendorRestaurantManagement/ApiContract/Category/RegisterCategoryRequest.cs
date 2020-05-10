namespace MultiVendorRestaurantManagement.ApiContract.Request
{
    public class RegisterCategoryRequest
    {
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string ImageUrl { get; set; }
        public string Categorize { get; set; }
    }
}
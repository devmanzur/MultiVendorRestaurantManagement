namespace MultiVendorRestaurantManagement.ApiContract.Request
{
    public class RegisterLocalityRequest
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
}
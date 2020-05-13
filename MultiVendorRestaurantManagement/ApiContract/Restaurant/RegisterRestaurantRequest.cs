namespace MultiVendorRestaurantManagement.ApiContract.Request
{
    public class RegisterRestaurantRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public long LocalityId { get; set; }
        public long CityId { get; set; }
        public long CategoryId { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public string SubscriptionType { get; set; }
        public string ContractStatus { get; set; }
        public string ImageUrl { get; set; }
    }
}
using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.ApiContract.Restaurant
{
    public class RegisterRestaurantRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public long LocalityId { get; set; }
        public long CityId { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public string SubscriptionType { get; set; }
        public string ContractStatus { get; set; }
        public string ImageUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string DescriptionEng { get; set; }

        public List<long> CategoryIds { get; set; }
        public List<long> CuisineIds { get; set; }
        
    }
}
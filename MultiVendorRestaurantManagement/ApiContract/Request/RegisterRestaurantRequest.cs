using System;
using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.Dto.Request
{
    public class RegisterRestaurantRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaCode { get; set; }
        public List<string> RestaurantCategories { get; set; }
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
        public string SubscriptionType { get; set; }
        public string ContractStatus { get; set; } 
    }
}
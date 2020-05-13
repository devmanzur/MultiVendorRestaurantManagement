using System;

namespace MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData
{
    public class RestaurantTableData
    {
        public long Id { get; set; }
        public long LocalityId { get; set; }
        public long ManagerId { get; set; }
        public long PricingPolicyId { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string SubscriptionType { get; set; }
        public string ContractStatus { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Rating { get; set; }
        public int TotalRatingsCount { get; set; }
    }
}
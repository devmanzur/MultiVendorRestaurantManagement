using System.Collections.Generic;
using Common.Invariants;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class RestaurantDocument : BaseDocument
    {
        public long RestaurantId { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public long LocalityId { get; private set; }
        public RestaurantState State { get; protected set; }
        public int OpeningHour { get; protected set; }
        public int ClosingHour { get; protected set; }
        public SubscriptionType SubscriptionType { get; protected set; }
        public ContractStatus ContractStatus { get; protected set; }
        public string ImageUrl { get; private set; }
        public double Rating { get; private set; }
        public int TotalRatingsCount { get; private set; }
        public List<MenuRecord> Menus { get; private set; }
        public List<RestaurantCategoryDocument> Categories { get; private set; }
        
    }

    public class MenuRecord
    {
        public long MenuId { get; private set; }
        public string Name { get; private set; }
        public string NameEng { get; protected set; }

    }
}
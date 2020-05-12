using System;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Deals
{
    public class FoodAddedToDealEvent : DomainEventBase
    {
        public long DealId { get; }
        public long FoodId { get; }
        public string Description { get; }
        public string DescriptionEng { get; }
        public DateTime EndDate { get; }

        public FoodAddedToDealEvent(in long dealId, in long foodId, string description, string descriptionEng,
            DateTime endDate)
        {
            DealId = dealId;
            FoodId = foodId;
            Description = description;
            DescriptionEng = descriptionEng;
            EndDate = endDate;
        }
    }
}
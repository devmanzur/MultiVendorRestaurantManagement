using System;
using System.Collections.Generic;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class Promotion : AggregateRoot
    {
        public Promotion(string imageUrl, string descriptionEng, string description,
            DateTime startDate, DateTime endDate)
        {
            ImageUrl = imageUrl;
            DescriptionEng = descriptionEng;
            Description = description;
            EndDate = endDate;
            StartDate = startDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private List<Food> _items = new List<Food>();
        public IReadOnlyList<Food> Items => _items.ToList();
        public string Description { get; protected set; }
        public string DescriptionEng { get; protected set; }
        public string ImageUrl { get; protected set; }
        public bool IsExclusive { get; protected set; } //if set true this will be available to only the 
        
        public override IDomainEvent GetAddedDomainEvent()
        {
            return new PromotionCreatedEvent();
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new PromotionRemovedEvent();
        }
    }
}
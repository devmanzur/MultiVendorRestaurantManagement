using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class CategoryCreatedEvent : DomainEventBase
    {
        public string CategoryName { get; }
        public Categorize Categorize { get; }

        public CategoryCreatedEvent(string categoryName, Categorize categorize)
        {
            CategoryName = categoryName;
            Categorize = categorize;
        }
    }
}
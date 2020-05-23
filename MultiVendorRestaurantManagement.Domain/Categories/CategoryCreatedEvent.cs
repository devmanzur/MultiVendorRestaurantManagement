using Common.Invariants;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Category
{
    public class CategoryCreatedEvent : DomainEventBase
    {
        public CategoryCreatedEvent(string categoryName, Categorize categorize)
        {
            CategoryName = categoryName;
            Categorize = categorize;
        }

        public string CategoryName { get; }
        public Categorize Categorize { get; }
    }
}
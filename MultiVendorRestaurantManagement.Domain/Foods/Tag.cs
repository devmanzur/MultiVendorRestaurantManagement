using System.Collections.Generic;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Foods
{
    public class Tag  : AggregateRoot
    {
        public Tag(string name, string nameEng)
        {
            Name = name;
            NameEng = nameEng;
        }
        public List<FoodTag> Foods { get; private set; }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public override IDomainEvent GetAddedDomainEvent()
        {
            return new TagCreatedEvent(Name);
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new TagDeletedEvent(Name);
        }
    }
}
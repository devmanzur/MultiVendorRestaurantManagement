using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class Review : AggregateRoot
    {
        public Review(int starRate, string comment, PhoneNumberValue userPhoneNumber, long itemId)
        {
            StarRate = starRate;
            Comment = comment;
            UserPhoneNumber = userPhoneNumber;
            ItemId = itemId;
        }

        public long ItemId { get;protected set; }
        public PhoneNumberValue UserPhoneNumber { get;protected set; }
        public int StarRate { get;protected set; }
        public string Comment { get; protected set; }

        public override IDomainEvent GetAddedDomainEvent()
        {
            return new ReviewAddedEvent();
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new ReviewDeletedEvent();
            ;
        }
    }
}
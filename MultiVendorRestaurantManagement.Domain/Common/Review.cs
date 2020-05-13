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

        public long ItemId { get; }
        public PhoneNumberValue UserPhoneNumber { get; }
        public int StarRate { get; }
        public string Comment { get; set; }

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
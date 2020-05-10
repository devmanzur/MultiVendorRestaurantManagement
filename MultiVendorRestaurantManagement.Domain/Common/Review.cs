using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Common
{
    public class Review : AggregateRoot 
    {
        public Review(int starRate, string comment, PhoneNumberCustomValue userPhoneNumberCustom, long itemId)
        {
            StarRate = starRate;
            Comment = comment;
            UserPhoneNumberCustom = userPhoneNumberCustom;
            ItemId = itemId;
        }

        public long ItemId { get; private set; }
        public PhoneNumberCustomValue UserPhoneNumberCustom { get; private set; }
        public int StarRate { get; private set; }
        public string Comment { get; set; }
        
        public override IDomainEvent GetAddedDomainEvent()
        {
            return new ReviewAddedEvent();
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new ReviewDeletedEvent();;
        }
    }
}
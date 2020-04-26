using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
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

        public long ItemId { get; private set; }
        public PhoneNumberValue UserPhoneNumber { get; private set; }
        public int StarRate { get; private set; }
        public string Comment { get; set; }
    }
}
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain
{
    public class Review : Entity
    {
        public Review(int starRate, string comment, PhoneNumberValue userPhoneNumber)
        {
            StarRate = starRate;
            Comment = comment;
            UserPhoneNumber = userPhoneNumber;
        }

        public PhoneNumberValue UserPhoneNumber { get; private set; }
        public int StarRate { get; private set; }
        public string Comment { get; set; }
    }
}
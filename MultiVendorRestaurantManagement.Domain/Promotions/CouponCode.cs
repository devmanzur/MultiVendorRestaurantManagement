using System;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class CouponCode : Entity
    {
        protected CouponCode()
        {
        }

        public CouponCode( string code,string username, string createdBy)
        {
            GeneratedAt = DateTime.Now;
            CreatedBy = createdBy;
            Code = code;
            Username = username;
            IsUsed = false;
            UsedBy = "none";
            IsDelivered = false;
        }


        public void Use(string phoneNumber)
        {
            UsedBy = phoneNumber;
            IsUsed = true;
        }

        public string Code { get; private set; }
        public string Username { get; private set; }
        public bool IsUsed { get; private set; }
        public bool IsDelivered { get; private set; }
        public DateTime GeneratedAt { get; private set; }
        public string UsedBy { get; private set; }
        public string CreatedBy { get; private set; }
    }
}
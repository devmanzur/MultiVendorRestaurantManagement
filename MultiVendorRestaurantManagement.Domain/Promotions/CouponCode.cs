using System;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Promotions
{
    public class CouponCode : Entity
    {
        protected CouponCode()
        {
        }

        public CouponCode(string code, string username, string createdBy)
        {
            GeneratedAt = DateTime.Now;
            CreatedBy = createdBy;
            Code = code;
            Username = username;
            IsUsed = false;
            UsedBy = "none";
            IsDelivered = false;
        }

        public string Code { get; protected set;}
        public string Username { get;protected set; }
        public bool IsUsed { get; private set; }
        public bool IsDelivered { get;protected set; }
        public DateTime GeneratedAt { get; protected set;}
        public string UsedBy { get; private set; }
        public string CreatedBy { get;protected set; }
        public Promotion Promotion { get; private set; }


        public void Use(string phoneNumber)
        {
            UsedBy = phoneNumber;
            IsUsed = true;
        }
    }
}
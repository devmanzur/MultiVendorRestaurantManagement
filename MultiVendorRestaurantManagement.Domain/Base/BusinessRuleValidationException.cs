using System;

namespace MultiVendorRestaurantManagement.Domain.Base
{
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; }

        public string Details { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.ErrorMessage)
        {
            BrokenRule = brokenRule;
            this.Details = brokenRule.ErrorMessage;
        }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.ErrorMessage}";
        }
    }
}
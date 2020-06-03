using System;

namespace BasketManagement.Domain.Base
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.ErrorMessage)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.ErrorMessage;
        }

        public IBusinessRule BrokenRule { get; }

        public string Details { get; }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.ErrorMessage}";
        }
    }
}
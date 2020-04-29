using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Rules
{
    public class ConditionMustBeTrue  : IBusinessRule
    {
        private readonly bool _condition;
        private readonly string _message;

        public ConditionMustBeTrue(bool condition, string message)
        {
            _condition = condition;
            _message = message;
        }

        public bool IsBroken() => !_condition;

        public string Message => _message;
    }
}
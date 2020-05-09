using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Rules
{
    public class ConditionMustBeTrueRule  : IBusinessRule
    {
        private readonly bool _conditionToBeValid;
        private readonly string _errorErrorMessage;

        public ConditionMustBeTrueRule(bool conditionToBeValid, string errorErrorMessage)
        {
            _conditionToBeValid = conditionToBeValid;
            _errorErrorMessage = errorErrorMessage;
        }

        public bool IsBroken() => !_conditionToBeValid;

        public string ErrorMessage => _errorErrorMessage;
    }
}
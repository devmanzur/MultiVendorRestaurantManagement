using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.ValueObjects;

namespace MultiVendorRestaurantManagement.Domain.Rules
{
    public class MoneyValueOperationMustBePerformedOnTheSameCurrencyRule : IBusinessRule
    {
        private readonly MoneyCustomValue _left;

        private readonly MoneyCustomValue _right;

        public MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(MoneyCustomValue left, MoneyCustomValue right)
        {
            _left = left;
            _right = right;
        }

        public bool IsBroken() => _left.Currency != _right.Currency;

        public string ErrorMessage => "Money value currencies must be the same";
    }
}
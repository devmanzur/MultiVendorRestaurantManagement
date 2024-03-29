﻿using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Rules
{
    public class MoneyValueMustHaveCurrencyRule : IBusinessRule
    {
        private readonly string _currency;

        public MoneyValueMustHaveCurrencyRule(string currency)
        {
            _currency = currency;
        }

        public bool IsBroken()
        {
            return string.IsNullOrEmpty(_currency);
        }

        public string ErrorMessage => "Money value must have currency";
    }
}
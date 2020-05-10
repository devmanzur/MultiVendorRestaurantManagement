using System;
using System.Collections.Generic;
using System.Linq;
using Common.Invariants;
using Common.Utils;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.ValueObjects
{
    public class MoneyCustomValue : CustomValueObject
    {
        public decimal Value { get; }

        public string Currency { get; }

        public string PriceTag => Currency + " " + Value;

        private MoneyCustomValue(decimal amount, string currency)
        {
            CheckRule(new ConditionMustBeTrueRule(amount.HasValue() && HelperFunctions.ValidAmount(amount),"invalid "));
            this.Value = amount;
            this.Currency = currency;
        }

        public static MoneyCustomValue Of(decimal value)
        {
            SupportedCurrency currency;
            if (value >= 1)
            {
                currency = SupportedCurrency.Euro;
            }
            else
            {
                currency = SupportedCurrency.Cent;
            }
            CheckRule(new MoneyValueMustHaveCurrencyRule(currency.ToDescriptionString()));

            return new MoneyCustomValue(value, currency.ToDescriptionString());
        }

        public static MoneyCustomValue Of(MoneyCustomValue customValue)
        {
            return new MoneyCustomValue(customValue.Value, customValue.Currency);
        }

        public static MoneyCustomValue operator +(MoneyCustomValue moneyCustomValueLeft, MoneyCustomValue moneyCustomValueRight)
        {
            CheckRule(new MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(moneyCustomValueLeft, moneyCustomValueRight));

            if (moneyCustomValueLeft.Currency != moneyCustomValueRight.Currency)
            {
                throw new ArgumentException();
            }

            return new MoneyCustomValue(moneyCustomValueLeft.Value + moneyCustomValueRight.Value, moneyCustomValueLeft.Currency);
        }

        public static MoneyCustomValue operator *(int number, MoneyCustomValue moneyCustomValueRight)
        {
            return new MoneyCustomValue(number * moneyCustomValueRight.Value, moneyCustomValueRight.Currency);
        }

        public static MoneyCustomValue operator *(decimal number, MoneyCustomValue moneyCustomValueRight)
        {
            return new MoneyCustomValue(number * moneyCustomValueRight.Value, moneyCustomValueRight.Currency);
        }
        
        
        
    }

    public static class SumExtensions
    {
        public static MoneyCustomValue Sum<T>(this IEnumerable<T> source, Func<T, MoneyCustomValue> selector)
        {
            return MoneyCustomValue.Of(source.Select(selector).Aggregate((x, y) => x + y));
        }

        public static MoneyCustomValue Sum(this IEnumerable<MoneyCustomValue> source)
        {
            return source.Aggregate((x, y) => x + y);
        }
    }
}
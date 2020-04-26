using Common.Invariants;
using CrossCutting;

namespace MultiVendorRestaurantManagement.Domain.ValueObjects
{
    public class PhoneNumberValue : ValueObject
    {
        protected PhoneNumberValue(string countryCode, string number)
        {
            CountryCode = countryCode;
            Number = number;
        }

        public string CountryCode { get; protected set; }
        public string Number { get; protected set; }

        public PhoneNumberValue Create(string phone)
        {
            return new PhoneNumberValue(CountryCodes.Italy, phone);
        }
    }
}
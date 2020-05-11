using Common.Invariants;
using Common.Utils;
using CrossCutting;

namespace MultiVendorRestaurantManagement.Domain.ValueObjects
{
    public class PhoneNumberValue : CustomValueObject
    {
        protected PhoneNumberValue(string countryCode, string number)
        {
            CountryCode = countryCode;
            Number = number;
        }

        public string CountryCode { get; protected set; }
        public string Number { get; protected set; }

        public string GetCompletePhoneNumber()
        {
            return CountryCode + Number;
        }
        
        public static PhoneNumberValue Of(SupportedCountryCode countryCode,string phone )
        {
            return new PhoneNumberValue(countryCode.ToDescriptionString(), phone);
        }
    }
}
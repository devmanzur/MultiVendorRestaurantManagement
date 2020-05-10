using Common.Invariants;
using Common.Utils;
using CrossCutting;

namespace MultiVendorRestaurantManagement.Domain.ValueObjects
{
    public class PhoneNumberCustomValue : CustomValueObject
    {
        protected PhoneNumberCustomValue(string countryCode, string number)
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
        
        public static PhoneNumberCustomValue Of(SupportedCountryCode countryCode,string phone )
        {
            return new PhoneNumberCustomValue(countryCode.ToDescriptionString(), phone);
        }
    }
}
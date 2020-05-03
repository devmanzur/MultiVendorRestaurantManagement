using System;

namespace Common.Utils
{
    public class HelperFunctions
    {
        private const string BaseUrl = "ya9bq8jd";
        public static string GenerateReferenceNumber()
        {
            var date = DateTime.Now;
            DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return BaseUrl + (long) (date.ToUniversalTime() - baseDate).TotalMilliseconds;
        }
    }
}
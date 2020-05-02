using System;

namespace Common.Utils
{
    public class HelperFunctions
    {
        public static long GenerateReferenceNumber()
        {
            var date = DateTime.Now;
            DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long) (date.ToUniversalTime() - baseDate).TotalMilliseconds;
        }
    }
}
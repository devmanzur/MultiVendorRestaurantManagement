using System.ComponentModel;

namespace Catalogue.Common.Invariants
{
    public enum SupportedCurrency
    {
        [Description("€")] Euro,
        [Description("¢")] Cent
    }

    public static class EnumExtensions
    {
        public static string ToDescriptionString<T>(this T e)
        {
            var info = e.GetType().GetField(e.ToString());
            var attributes = (DescriptionAttribute[]) info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // ?? is equivalent to ?: of kotlin 
            return attributes[0]?.Description ?? e.ToString();
        }
    }
}
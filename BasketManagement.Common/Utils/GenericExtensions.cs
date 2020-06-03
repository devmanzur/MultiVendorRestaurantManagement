#nullable enable
namespace BasketManagement.Common.Utils
{
    public static class GenericExtensions
    {
        public static bool HasNoValue(this object? item)
        {
            if (item is string s) return string.IsNullOrEmpty(s);
            return item == null;
        }

        public static bool HasValue(this object? item)
        {
            if (item is string s) return !string.IsNullOrEmpty(s);
            return item != null;
        }
    }
}
namespace Catalogue.Common.Invariants
{
    public enum Categorize
    {
        Invalid,
        Restaurant,
        Food
    }

    public static class CategorizeHelper
    {
        public static Categorize ConvertToCategorize(string item)
        {
            if (string.IsNullOrEmpty(item)) return Categorize.Invalid;

            return item.ToLowerInvariant() switch
            {
                "food" => Categorize.Food,
                "restaurant" => Categorize.Restaurant,
                _ => Categorize.Invalid
            };
        }
    }
}
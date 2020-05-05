namespace Common.Invariants
{
    public enum FoodItemType
    {
        Invalid,
        Single,
        Combo
    }

    public static class FoodItemTypeHelper
    {
        public static FoodItemType ConvertToFoodItemType(string item)
        {
            if (string.IsNullOrEmpty(item)) return FoodItemType.Invalid;

            return item.ToLowerInvariant() switch
            {
                "single" => FoodItemType.Single,
                "combo" => FoodItemType.Combo,
                _ => FoodItemType.Invalid
            };
        }
    }
}
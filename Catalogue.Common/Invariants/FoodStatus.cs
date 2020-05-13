namespace Catalogue.Common.Invariants
{
    public enum FoodStatus
    {
        Invalid,
        Available,
        Unavailable,
        OutOfStock
    }

    public static class FoodStatsHelper
    {
        public static FoodStatus GetStatusFrom(bool isActive)
        {
            if (isActive)
                return FoodStatus.Available;
            return FoodStatus.OutOfStock;
        }
    }
}
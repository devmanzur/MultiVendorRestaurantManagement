using System;
using System.Linq;
using System.Linq.Expressions;
using Catalogue.ApiContract.Response;
using Catalogue.Infrastracture.Mongo.Documents;
using Catalogue.Infrastructure.ValueObject;

namespace Catalogue.Utils
{
    public static class Projections
    {
        public static Expression<Func<CategoryDocument, CategoryMinimalDto>> MinimalCategoryProjection()
        {
            return x => new CategoryMinimalDto(x.CategoryId, x.Name, x.ImageUrl);
        }

        public static Expression<Func<FoodDocument, FoodMinimalDto>> MinimalFoodProjection()
        {
            return x => new FoodMinimalDto(x.FoodId, x.Name, x.RestaurantId, x.RestaurantName, x.CategoryId,
                x.CategoryName, x.Rating, x.OldUnitPrice, x.UnitPrice, MoneyValue.Of(x.UnitPrice).PriceTag,
                x.DealId, x.DealDescription);
        }

        public static Expression<Func<RestaurantDocument, RestaurantMinimalDto>> MinimalRestaurantProjection()
        {
            return x => new RestaurantMinimalDto(x.RestaurantId, x.Name, x.Rating, x.ImageUrl, x.GetState());
        }

        public static Expression<Func<DealDocument, DealMinimalDto>> MinimalDealProjection()
        {
            return x => new DealMinimalDto(x.DealId, x.Name, x.ImageUrl, x.Description);
        }

    }
}
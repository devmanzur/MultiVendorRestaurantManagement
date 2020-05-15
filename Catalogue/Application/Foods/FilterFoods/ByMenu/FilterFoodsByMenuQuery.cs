using Catalogue.ApiContract.Pagination;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Foods.FilterFoods
{
    public class FilterFoodsByMenuQuery : IQuery<Result<IPagedList<FoodMinimalDto>>>
    {
        public long RestaurantId { get; }
        public long MenuId { get; }
        public int PageNumber { get; }
        public int PageSize { get;}
        public string OrderBy { get; }

        public FilterFoodsByMenuQuery(GeneralPaginationQuery paginationQuery, long restaurantId, long menuId)
        {
            RestaurantId = restaurantId;
            MenuId = menuId;
            PageNumber = paginationQuery.PageNumber;
            PageSize = paginationQuery.PageSize;
            OrderBy = paginationQuery.OrderBy;
            
        }
    }
}
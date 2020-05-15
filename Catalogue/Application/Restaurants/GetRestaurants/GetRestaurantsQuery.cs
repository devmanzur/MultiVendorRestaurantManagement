using System.Collections.Generic;
using Catalogue.ApiContract.Pagination;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Restaurants.GetRestaurants
{
    public class GetRestaurantsQuery  : IQuery<Result<IPagedList<RestaurantMinimalDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string FilterBy { get; set; }
        public string FilterValue { get; set; }
        
        public GetRestaurantsQuery(GeneralPaginationQuery paginationQuery)
        {
            PageNumber = paginationQuery.PageNumber;
            PageSize = paginationQuery.PageSize;
            OrderBy = paginationQuery.OrderBy;
            FilterBy = paginationQuery.FilterBy;
            FilterValue = paginationQuery.FilterValue;
        }
    }
}
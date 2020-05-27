using Catalogue.ApiContract.Pagination;
using Catalogue.ApiContract.Response;
using Catalogue.Application.Base;
using Catalogue.Base;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Foods.FilterFoods
{
    public class FilterFoodsQuery : IQuery<Result<IPagedList<FoodMinimalDto>>>
    {
        public int PageNumber { get; }
        public int PageSize { get; private set; }
        public string OrderBy { get; }
        public string FilterBy { get; }
        public long FilterValue { get; }

        public FilterFoodsQuery(GeneralPaginationQuery paginationQuery, long filterValue, string filterBy)
        {
            PageNumber = paginationQuery.PageNumber;
            PageSize = paginationQuery.PageSize;
            OrderBy = paginationQuery.OrderBy;
            FilterBy = filterBy;
            FilterValue = filterValue;
        }
        
    }
}
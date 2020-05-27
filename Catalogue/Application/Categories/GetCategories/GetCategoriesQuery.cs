using Catalogue.ApiContract.Pagination;
using Catalogue.ApiContract.Response;
using Catalogue.Application.Base;
using Catalogue.Base;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Categories.GetCategories
{
    public class GetCategoriesQuery : IQuery<Result<IPagedList<CategoryMinimalDto>>>
    {
        public int PageNumber { get; }
        public int PageSize { get; }

        public GetCategoriesQuery(GeneralPaginationQuery paginationQuery)
        {
            PageNumber = paginationQuery.PageNumber;
            PageSize = paginationQuery.PageSize;
            OrderBy = paginationQuery.OrderBy ?? "";
        }

        public string OrderBy { get; }
    }
}
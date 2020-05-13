using System.Collections.Generic;
using Catalogue.ApiContract.Pagination;
using Catalogue.ApiContract.Response;
using Catalogue.Base;
using CSharpFunctionalExtensions;

namespace Catalogue.Application.Deals
{
    public class GetDealsQuery : IQuery<Result<IPagedList<DealMinimalDto>>>
    {
        public GetDealsQuery(GeneralPaginationQuery paginationQuery)
        {
            PageNumber = paginationQuery.PageNumber;
            PageSize = paginationQuery.PageSize;
            OrderBy = paginationQuery.OrderBy;
        }

        public string OrderBy { get; }

        public int PageSize { get; }

        public int PageNumber { get; }
    }
}
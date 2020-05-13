using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Catalogue.ApiContract.Pagination
{
    public static class PaginationHelper
    {
        public static IPagedList<T> ToPagedList<T>(this List<T> source, int pageIndex, int pageSize, int count = 0,
            int indexFrom = 0, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (indexFrom > pageIndex)
            {
                throw new ArgumentException(
                    $"indexFrom: {indexFrom} > pageNumber: {pageIndex}, must indexFrom <= pageNumber");
            }

            var items = source;

            var pagedList = new PagedList<T>
            {
                PageNumber = pageIndex,
                PageSize = pageSize,
                Items = items,
                IndexFrom = indexFrom,
                TotalCount = count,
                TotalPages = count > 0 ? (int) Math.Ceiling(count / (double) pageSize) : 0
            };

            return pagedList;
        }

        public static int? Skip(in int pageNumber, in int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;
            return skip < 0 ? 0 : skip;
        }
    }
}
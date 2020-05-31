﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace MessengerBotAPI.ApiContract.Pagination
{
    public static class PaginationHelper
    {
        public static IPagedList<T> ToPagedList<T>(this List<T> source, int pageIndex = 1, int pageSize = 20,
            int count = 0,
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

        public static int? Skip(in int pageNumber = 1, in int pageSize = 20)
        {
            var skip = (pageNumber - 1) * pageSize;
            return skip < 0 ? 0 : skip;
        }
    }
}
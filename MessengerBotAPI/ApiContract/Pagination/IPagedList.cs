﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MessengerBotAPI.ApiContract.Pagination
{
 
    public interface IPagedList<T>
    {
        /// <summary>
        /// Gets the Index Start Value
        /// </summary>
        int IndexFrom { get; }

        /// <summary>
        /// Gets the Page Number
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Gets the Page Size
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the Total Count of the list of <typeparamref name="T" />
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the Total Pages
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Gets the Current Page Items
        /// </summary>
        IList<T> Items { get; }

        /// <summary>
        /// Gets a value indicating whether the paged list has a previous page
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Gets a value indicating whether the paged list has a next page
        /// </summary>
        bool HasNextPage { get; }
    }
    
       public class PagedList<T> : IPagedList<T>
    {
        /// <inheritdoc />
        public int PageNumber { get; set; }

        /// <inheritdoc />
        public int PageSize { get; set; }

        /// <inheritdoc />
        public int TotalCount { get; set; }

        /// <inheritdoc />
        public int TotalPages { get; set; }

        /// <inheritdoc />
        public int IndexFrom { get; set; }

        /// <inheritdoc />
        public IList<T> Items { get; set; }

        public bool HasPreviousPage => this.PageNumber - this.IndexFrom > 0;

        public bool HasNextPage => this.PageNumber - this.IndexFrom + 1 < this.TotalPages;

       
        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize, int totalCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.IndexFrom = pageNumber * pageSize;

            var itemList = source.ToList();
            this.TotalCount = totalCount;
            this.TotalPages = totalCount>0? (int) Math.Ceiling(this.TotalCount / (double) this.PageSize) : 0;

            this.Items = itemList;
        }

        public PagedList()
        {
            this.Items = new T[0];
        }
    }

  
    public class PagedList<TSource, TResult> : IPagedList<TResult>
    {
        /// <inheritdoc />
        public int PageNumber { get; }

        /// <inheritdoc />
        public int PageSize { get; }

        /// <inheritdoc />
        public int TotalCount { get; }

        /// <inheritdoc />
        public int TotalPages { get; }

        /// <inheritdoc />
        public int IndexFrom { get; }

        /// <inheritdoc />
        public IList<TResult> Items { get; }

        /// <inheritdoc />
        public bool HasPreviousPage => this.PageNumber - this.IndexFrom > 0;

        /// <inheritdoc />
        public bool HasNextPage => this.PageNumber - this.IndexFrom + 1 < this.TotalPages;

        
        public PagedList(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
            int pageIndex, int pageSize, int indexFrom)
        {
            if (source is IQueryable<TSource> queryable)
            {
                this.PageNumber = pageIndex;
                this.PageSize = pageSize;
                this.IndexFrom = indexFrom;
                this.TotalCount = queryable.Count();
                this.TotalPages = (int) Math.Ceiling(this.TotalCount / (double) this.PageSize);

                var items = queryable.Skip((this.PageNumber - this.IndexFrom) * this.PageSize).Take(this.PageSize)
                    .ToArray();
                this.Items = new List<TResult>(converter(items));
            }
            else
            {
                this.PageNumber = pageIndex;
                this.PageSize = pageSize;
                this.IndexFrom = indexFrom;

                var itemList = source.ToList();
                this.TotalCount = itemList.Count;
                this.TotalPages = (int) Math.Ceiling(this.TotalCount / (double) this.PageSize);

                var items = itemList.Skip((this.PageNumber - this.IndexFrom) * this.PageSize).Take(this.PageSize)
                    .ToArray();
                this.Items = new List<TResult>(converter(items));
            }
        }

       
        public PagedList(IPagedList<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            this.PageNumber = source.PageNumber;
            this.PageSize = source.PageSize;
            this.IndexFrom = source.IndexFrom;
            this.TotalCount = source.TotalCount;
            this.TotalPages = source.TotalPages;
            this.Items = new List<TResult>(converter(source.Items));
        }
    }

    public static class PagedList
    {
        
        public static IPagedList<T> Empty<T>() => new PagedList<T>();

       
        public static IPagedList<TResult> From<TResult, TSource>(IPagedList<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter) =>
            new PagedList<TSource, TResult>(source, converter);
    }
}
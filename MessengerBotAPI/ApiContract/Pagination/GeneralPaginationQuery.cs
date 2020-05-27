﻿namespace MessengerBotAPI.ApiContract.Pagination
{
    public class GeneralPaginationQuery
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public string OrderBy { get; set; }

        public string FilterBy { get; set; }
        public string FilterValue { get; set; }
        
        private int _pageSize = 20;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize || value <= 0) ? MaxPageSize : value;
        }
    }
}
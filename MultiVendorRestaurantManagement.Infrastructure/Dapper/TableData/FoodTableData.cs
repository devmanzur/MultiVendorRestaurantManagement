﻿namespace MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData
{
    public class FoodTableData
    {
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public long CategoryId { get; set; }
        public long CuisineId { get; set; }
        public long DealId { get; set; }
        public long MenuId { get; set; }
        public string Description { get; set; }
        public string DescriptionEng { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsVeg { get; set; }
        public bool IsNonVeg { get; set; }
        public double Rating { get; set; }
        public int TotalRatingCount { get; set; }
    }
}
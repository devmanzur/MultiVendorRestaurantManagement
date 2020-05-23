namespace MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData
{
    public class CategoryTableData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string ImageUrl { get; set; }
        public string Categorize { get; set; }
    }

    public class CategoryTableDataMinimal
    {
        public string Name { get; set; }
        public string NameEng { get; set; }
        public long Id { get; set; }
    }
}
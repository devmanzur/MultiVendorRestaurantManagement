namespace MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData
{
    public class MenuTableData
    {
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string ImageUrl { get; set; }

    }
    
    public class MenuTableData2
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string ImageUrl { get; set; }
    }
    
    
}
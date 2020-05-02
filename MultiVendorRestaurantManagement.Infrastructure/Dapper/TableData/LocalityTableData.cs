namespace MultiVendorRestaurantManagement.Infrastructure.Dapper.DbView
{
    public class LocalityTableData
    {
        public long Id { get;  set; }
        public long CityId { get;  set; }
        public int Code { get;  set; }
        public string Name { get;  set; }
        public string NameEng { get;  set; }
    }
}
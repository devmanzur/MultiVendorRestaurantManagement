using MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData;
using MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents;

namespace MultiVendorRestaurantManagement.Infrastructure.Dapper.Converters
{
    public static class Converters
    {
        public static CategoryRecord ToRecord(this CategoryTableDataMinimal data)
        {
            return new CategoryRecord
            {
                Id = data.Id,
                Name = data.Name,
                NameEng = data.NameEng
            };
        }
        public static CuisineRecord ToRecord(this CuisineTableDataMinimal data)
        {
            return new CuisineRecord
            {
                Id = data.Id,
                Name = data.Name,
                NameEng = data.NameEng
            };
        }
    }
}
using System.Threading.Tasks;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.DbView;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData;

namespace MultiVendorRestaurantManagement.Infrastructure.Dapper
{
    public interface ITableDataProvider
    {
        Task<LocalityTableData> GetLocalityAsync(long notificationCityId, string notificationLocalityName);
        Task<CityTableData> GetCityAsync(string name);
        Task<CategoryTableData> GetCategoryAsync(string name);
    }
}
using System.Threading.Tasks;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.DbView;

namespace MultiVendorRestaurantManagement.Infrastructure.Dapper
{
    public interface ITableDataProvider
    {
        Task<LocalityTableData> GetLocalityDataAsync(long notificationCityId, string notificationLocalityName);
        Task<CityTableData> GetCityDataAsync(string name);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.DbView;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData;

namespace MultiVendorRestaurantManagement.Infrastructure.Dapper
{
    public interface ITableDataProvider
    {
        Task<LocalityTableData> GetLocality(long cityId, string localityName);
        Task<CityTableData> GetCity(string name);
        Task<CategoryTableData> GetCategory(string name);
        Task<RestaurantTableData> GetRestaurant(string phone);
        Task<MenuTableData2> GetMenu(string menuName);
        Task<FoodTableData> GetFood(long restaurantId, string foodName);
        Task<DealTableData> GetDeal(string notificationDealName);
        Task<List<CuisineTableDataMinimal>> GetCuisineList(IEnumerable<long> cuisineIds);
        Task<List<CategoryTableDataMinimal>> GetCategoryList(IEnumerable<long> categoryIds);
        Task<GeographicLocationTableData> GetGeoGraphicLocation(long restaurantId);
    }
}
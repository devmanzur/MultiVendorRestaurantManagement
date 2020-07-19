using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.DbView;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData;

namespace MultiVendorRestaurantManagement.Infrastructure.Dapper
{
    public class TableDataProvider : ITableDataProvider
    {
        private readonly string _connectionString;

        public TableDataProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlDatabase");
        }

        public async Task<LocalityTableData> GetLocality(long cityId, string localityName)
        {
            const string sql = "SELECT * FROM Locality WHERE (Name = @Name AND CityId = @CityId)";
            await using var connection = new SqlConnection(_connectionString);
            var locality =
                await connection.QueryFirstOrDefaultAsync<LocalityTableData>(sql,
                    new {Name = localityName, CityId = cityId});
            return locality;
        }

        public async Task<CityTableData> GetCity(string name)
        {
            const string sql = "SELECT * FROM Cities WHERE Name = @Name";
            await using var connection = new SqlConnection(_connectionString);
            var city =
                await connection.QueryFirstOrDefaultAsync<CityTableData>(sql,
                    new {Name = name});
            return city;
        }

        public async Task<CategoryTableData> GetCategory(string name)
        {
            const string sql = "SELECT * FROM Categories WHERE Name = @Name";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<CategoryTableData>(sql,
                    new {Name = name});
            return item;
        }

        public async Task<RestaurantTableData> GetRestaurant(string phone)
        {
            const string sql = "select * from Restaurants where PhoneNumber = @PhoneNumber";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<RestaurantTableData>(sql,
                    new {PhoneNumber = phone});
            return item;
        }

        public async Task<MenuTableData2> GetMenu(string menuName)
        {
            const string sql = "select * from Menu where Name = @Name";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<MenuTableData2>(sql,
                    new {Name = menuName});
            return item;
        }

        public async Task<FoodTableData> GetFood(long restaurantId, string foodName)
        {
            const string sql = "SELECT * FROM Food WHERE (Name = @Name AND RestaurantId = @RestaurantId)";
            await using var connection = new SqlConnection(_connectionString);
            var item = await connection.QueryFirstOrDefaultAsync<FoodTableData>(sql,
                new {Name = foodName, RestaurantId = restaurantId});
            return item;
        }

        public async Task<DealTableData> GetDeal(string dealName)
        {
            const string sql = "select * from Deals where Name = @Name";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<DealTableData>(sql,
                    new {Name = dealName});
            return item;
        }

        public async Task<List<CuisineTableDataMinimal>> GetCuisineList(IEnumerable<long> cuisineIds)
        {
            const string sql = "SELECT * FROM Cuisines WHERE Id IN @ids";
            await using var connection = new SqlConnection(_connectionString);
            var results = await connection.QueryAsync<CuisineTableDataMinimal>(sql, new {ids = cuisineIds});
            return results.ToList();
        }

        public async Task<List<CategoryTableDataMinimal>> GetCategoryList(IEnumerable<long> categoryIds)
        {
            const string sql = "SELECT * FROM Categories WHERE Id IN @ids";
            await using var connection = new SqlConnection(_connectionString);
            var results = await connection.QueryAsync<CategoryTableDataMinimal>(sql, new {ids = categoryIds});
            return results.ToList();
        }

        public async Task<GeographicLocationTableData> GetGeoGraphicLocation(long restaurantId)
        {
            const string sql = "select * from GeographicLocation where RestaurantId = @RestaurantId";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<GeographicLocationTableData>(sql,
                    new {RestaurantId = restaurantId});
            return item;
        }
    }
}
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.DbView;
using MultiVendorRestaurantManagement.Infrastructure.Dapper.TableData;

namespace MultiVendorRestaurantManagement.Infrastructure.Dapper
{
    public class TableDataProvider : ITableDataProvider
    {
        private string _connectionString;

        public TableDataProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<LocalityTableData> GetLocalityAsync(long cityId, string localityName)
        {
            const string sql = "SELECT * FROM Locality WHERE (Name = @Name AND CityId = @CityId)";
            await using var connection = new SqlConnection(_connectionString);
            var locality =
                await connection.QueryFirstOrDefaultAsync<LocalityTableData>(sql,
                    new {Name = localityName, CityId = cityId});
            return locality;
        }

        public async Task<CityTableData> GetCityAsync(string name)
        {
            const string sql = "SELECT * FROM Cities WHERE Name = @Name";
            await using var connection = new SqlConnection(_connectionString);
            var city =
                await connection.QueryFirstOrDefaultAsync<CityTableData>(sql,
                    new {Name = name});
            return city;
        }

        public async Task<CategoryTableData> GetCategoryAsync(string name)
        {
            const string sql = "select * from Categories where Name = @Name";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<CategoryTableData>(sql,
                    new {Name = name});
            return item;
        }

        public async Task<RestaurantTableData> GetRestaurantAsync(string phone)
        {
            const string sql = "select * from Restaurants where PhoneNumber = @PhoneNumber";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<RestaurantTableData>(sql,
                    new {PhoneNumber = phone});
            return item;
        }

        public async Task<MenuTableData2> GetMenuAsync(string menuName)
        {
            const string sql = "select * from Menu where Name = @Name";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<MenuTableData2>(sql,
                    new {Name = menuName});
            return item;
        }

        public async Task<FoodTableData> GetFoodAsync(long restaurantId, string foodName)
        {
            const string sql = "SELECT * FROM Food WHERE (Name = @Name AND RestaurantId = @RestaurantId)";
            await using var connection = new SqlConnection(_connectionString);
            var item = await connection.QueryFirstOrDefaultAsync<FoodTableData>(sql,
                new {Name = foodName, RestaurantId = restaurantId});
            return item;
        }

        public async Task<DealTableData> GetDealAsync(string dealName)
        {
            const string sql = "select * from Deals where Name = @Name";
            await using var connection = new SqlConnection(_connectionString);
            var item =
                await connection.QueryFirstOrDefaultAsync<DealTableData>(sql,
                    new {Name = dealName});
            return item;
        }
    }
}
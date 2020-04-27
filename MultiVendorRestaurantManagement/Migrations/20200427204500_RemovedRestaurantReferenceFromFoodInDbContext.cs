using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Migrations
{
    public partial class RemovedRestaurantReferenceFromFoodInDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Restaurants_RestaurantId1",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_RestaurantId1",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "Food");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RestaurantId1",
                table: "Food",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_RestaurantId1",
                table: "Food",
                column: "RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Restaurants_RestaurantId1",
                table: "Food",
                column: "RestaurantId1",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

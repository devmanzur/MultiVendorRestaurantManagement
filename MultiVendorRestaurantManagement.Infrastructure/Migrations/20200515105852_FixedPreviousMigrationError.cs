using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class FixedPreviousMigrationError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_GeographicLocation_LocationId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_LocationId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Restaurants");

            migrationBuilder.AddColumn<long>(
                name: "RestaurantId",
                table: "GeographicLocation",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GeographicLocation_RestaurantId",
                table: "GeographicLocation",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicLocation_Restaurants_RestaurantId",
                table: "GeographicLocation",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicLocation_Restaurants_RestaurantId",
                table: "GeographicLocation");

            migrationBuilder.DropIndex(
                name: "IX_GeographicLocation_RestaurantId",
                table: "GeographicLocation");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "GeographicLocation");

            migrationBuilder.AddColumn<long>(
                name: "LocationId",
                table: "Restaurants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_LocationId",
                table: "Restaurants",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_GeographicLocation_LocationId",
                table: "Restaurants",
                column: "LocationId",
                principalTable: "GeographicLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

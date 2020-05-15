using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class AddedLocationToRestaurantAndDescriptionToFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEng",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LocationId",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Food",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEng",
                table: "Food",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Deals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeographicLocation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicLocation", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_GeographicLocation_LocationId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "GeographicLocation");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_LocationId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "DescriptionEng",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "DescriptionEng",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Deals");
        }
    }
}

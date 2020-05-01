using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Migrations
{
    public partial class AddedCategoryDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categorize",
                table: "Categories",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorize",
                table: "Categories");
        }
    }
}

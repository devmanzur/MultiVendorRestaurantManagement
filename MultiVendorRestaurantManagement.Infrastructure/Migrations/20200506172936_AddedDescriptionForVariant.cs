using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class AddedDescriptionForVariant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Description",
                "Variant",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                "DescriptionEng",
                "Variant",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Description",
                "Variant");

            migrationBuilder.DropColumn(
                "DescriptionEng",
                "Variant");
        }
    }
}
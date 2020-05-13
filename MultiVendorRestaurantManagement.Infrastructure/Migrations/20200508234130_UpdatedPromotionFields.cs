using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class UpdatedPromotionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Name",
                "Promotions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                "IX_Promotions_EndDate",
                "Promotions",
                "EndDate");

            migrationBuilder.CreateIndex(
                "IX_Promotions_Name",
                "Promotions",
                "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "IX_Promotions_EndDate",
                "Promotions");

            migrationBuilder.DropIndex(
                "IX_Promotions_Name",
                "Promotions");

            migrationBuilder.DropColumn(
                "Name",
                "Promotions");
        }
    }
}
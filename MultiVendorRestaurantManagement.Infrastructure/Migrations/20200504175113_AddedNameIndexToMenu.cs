using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class AddedNameIndexToMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "NameEng",
                "Menu",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Menu",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                "IX_Menu_Name",
                "Menu",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Menu_NameEng",
                "Menu",
                "NameEng",
                unique: true,
                filter: "[NameEng] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "IX_Menu_Name",
                "Menu");

            migrationBuilder.DropIndex(
                "IX_Menu_NameEng",
                "Menu");

            migrationBuilder.AlterColumn<string>(
                "NameEng",
                "Menu",
                "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Menu",
                "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
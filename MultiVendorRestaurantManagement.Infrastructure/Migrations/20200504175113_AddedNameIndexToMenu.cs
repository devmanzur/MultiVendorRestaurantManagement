using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class AddedNameIndexToMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Menu",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menu",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Name",
                table: "Menu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_NameEng",
                table: "Menu",
                column: "NameEng",
                unique: true,
                filter: "[NameEng] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Menu_Name",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_NameEng",
                table: "Menu");

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

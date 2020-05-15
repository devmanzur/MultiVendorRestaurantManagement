using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class MadeMenuMandatoryInFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Menu_MenuId",
                table: "Food");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Menu_MenuId",
                table: "Food",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Menu_MenuId",
                table: "Food");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Menu_MenuId",
                table: "Food",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

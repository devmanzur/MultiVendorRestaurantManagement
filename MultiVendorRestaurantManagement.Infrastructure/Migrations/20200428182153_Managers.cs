using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Migrations
{
    public partial class Managers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Restaurants_RestaurantId",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_RestaurantId",
                table: "Managers",
                newName: "IX_Managers_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Restaurants_RestaurantId",
                table: "Managers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Restaurants_RestaurantId",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_RestaurantId",
                table: "Manager",
                newName: "IX_Manager_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Restaurants_RestaurantId",
                table: "Manager",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

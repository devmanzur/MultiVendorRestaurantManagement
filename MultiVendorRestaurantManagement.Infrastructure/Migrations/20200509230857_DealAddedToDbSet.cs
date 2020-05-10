using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class DealAddedToDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Deal_DealId",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deal",
                table: "Deal");

            migrationBuilder.RenameTable(
                name: "Deal",
                newName: "Deals");

            migrationBuilder.RenameIndex(
                name: "IX_Deal_StartDate",
                table: "Deals",
                newName: "IX_Deals_StartDate");

            migrationBuilder.RenameIndex(
                name: "IX_Deal_Name",
                table: "Deals",
                newName: "IX_Deals_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Deal_EndDate",
                table: "Deals",
                newName: "IX_Deals_EndDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deals",
                table: "Deals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Deals_DealId",
                table: "Food",
                column: "DealId",
                principalTable: "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Deals_DealId",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deals",
                table: "Deals");

            migrationBuilder.RenameTable(
                name: "Deals",
                newName: "Deal");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_StartDate",
                table: "Deal",
                newName: "IX_Deal_StartDate");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_Name",
                table: "Deal",
                newName: "IX_Deal_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_EndDate",
                table: "Deal",
                newName: "IX_Deal_EndDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deal",
                table: "Deal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Deal_DealId",
                table: "Food",
                column: "DealId",
                principalTable: "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

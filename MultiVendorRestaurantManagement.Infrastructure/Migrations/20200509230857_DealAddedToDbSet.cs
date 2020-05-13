using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class DealAddedToDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Food_Deal_DealId",
                "Food");

            migrationBuilder.DropPrimaryKey(
                "PK_Deal",
                "Deal");

            migrationBuilder.RenameTable(
                "Deal",
                newName: "Deals");

            migrationBuilder.RenameIndex(
                "IX_Deal_StartDate",
                table: "Deals",
                newName: "IX_Deals_StartDate");

            migrationBuilder.RenameIndex(
                "IX_Deal_Name",
                table: "Deals",
                newName: "IX_Deals_Name");

            migrationBuilder.RenameIndex(
                "IX_Deal_EndDate",
                table: "Deals",
                newName: "IX_Deals_EndDate");

            migrationBuilder.AddPrimaryKey(
                "PK_Deals",
                "Deals",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Food_Deals_DealId",
                "Food",
                "DealId",
                "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Food_Deals_DealId",
                "Food");

            migrationBuilder.DropPrimaryKey(
                "PK_Deals",
                "Deals");

            migrationBuilder.RenameTable(
                "Deals",
                newName: "Deal");

            migrationBuilder.RenameIndex(
                "IX_Deals_StartDate",
                table: "Deal",
                newName: "IX_Deal_StartDate");

            migrationBuilder.RenameIndex(
                "IX_Deals_Name",
                table: "Deal",
                newName: "IX_Deal_Name");

            migrationBuilder.RenameIndex(
                "IX_Deals_EndDate",
                table: "Deal",
                newName: "IX_Deal_EndDate");

            migrationBuilder.AddPrimaryKey(
                "PK_Deal",
                "Deal",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Food_Deal_DealId",
                "Food",
                "DealId",
                "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
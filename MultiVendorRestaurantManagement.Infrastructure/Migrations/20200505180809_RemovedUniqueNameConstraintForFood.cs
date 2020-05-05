using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class RemovedUniqueNameConstraintForFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Food_Name",
                table: "Food");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Name",
                table: "Food",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Food_Name",
                table: "Food");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Name",
                table: "Food",
                column: "Name",
                unique: true);
        }
    }
}

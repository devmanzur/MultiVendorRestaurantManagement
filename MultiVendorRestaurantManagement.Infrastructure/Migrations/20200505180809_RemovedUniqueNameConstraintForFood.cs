using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class RemovedUniqueNameConstraintForFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "IX_Food_Name",
                "Food");

            migrationBuilder.CreateIndex(
                "IX_Food_Name",
                "Food",
                "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "IX_Food_Name",
                "Food");

            migrationBuilder.CreateIndex(
                "IX_Food_Name",
                "Food",
                "Name",
                unique: true);
        }
    }
}
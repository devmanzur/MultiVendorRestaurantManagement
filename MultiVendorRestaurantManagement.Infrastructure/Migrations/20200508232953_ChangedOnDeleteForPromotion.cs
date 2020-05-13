using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Infrastructure.Migrations
{
    public partial class ChangedOnDeleteForPromotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Food_Categories_CategoryId",
                "Food");

            migrationBuilder.DropForeignKey(
                "FK_Food_Promotions_PromotionId",
                "Food");

            migrationBuilder.DropForeignKey(
                "FK_Restaurants_Categories_CategoryId",
                "Restaurants");

            migrationBuilder.AddForeignKey(
                "FK_Food_Categories_CategoryId",
                "Food",
                "CategoryId",
                "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Food_Promotions_PromotionId",
                "Food",
                "PromotionId",
                "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                "FK_Restaurants_Categories_CategoryId",
                "Restaurants",
                "CategoryId",
                "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Food_Categories_CategoryId",
                "Food");

            migrationBuilder.DropForeignKey(
                "FK_Food_Promotions_PromotionId",
                "Food");

            migrationBuilder.DropForeignKey(
                "FK_Restaurants_Categories_CategoryId",
                "Restaurants");

            migrationBuilder.AddForeignKey(
                "FK_Food_Categories_CategoryId",
                "Food",
                "CategoryId",
                "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                "FK_Food_Promotions_PromotionId",
                "Food",
                "PromotionId",
                "Promotions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                "FK_Restaurants_Categories_CategoryId",
                "Restaurants",
                "CategoryId",
                "Categories",
                principalColumn: "Id");
        }
    }
}
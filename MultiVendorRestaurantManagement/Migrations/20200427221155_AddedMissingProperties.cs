using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiVendorRestaurantManagement.Migrations
{
    public partial class AddedMissingProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Food_FoodId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Promotions_PromotionId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Restaurants_RestaurantId",
                table: "RestaurantCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantCategory",
                table: "RestaurantCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "RestaurantCategory",
                newName: "RestaurantCategories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "FoodCategories");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCategory_RestaurantId",
                table: "RestaurantCategories",
                newName: "IX_RestaurantCategories_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_FoodId",
                table: "FoodCategories",
                newName: "IX_FoodCategories_FoodId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRatingsCount",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameEng",
                table: "Locality",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PromotionId",
                table: "Food",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Food",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Food",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRatingsCount",
                table: "Food",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantCategories",
                table: "RestaurantCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodCategories",
                table: "FoodCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(nullable: false),
                    UserPhoneNumber = table.Column<string>(nullable: true),
                    StarRate = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Promotions_PromotionId",
                table: "Food",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCategories_Food_FoodId",
                table: "FoodCategories",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategories_Restaurants_RestaurantId",
                table: "RestaurantCategories",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Promotions_PromotionId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategories_Food_FoodId",
                table: "FoodCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategories_Restaurants_RestaurantId",
                table: "RestaurantCategories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantCategories",
                table: "RestaurantCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodCategories",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "TotalRatingsCount",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "NameEng",
                table: "Locality");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "TotalRatingsCount",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "RestaurantCategories",
                newName: "RestaurantCategory");

            migrationBuilder.RenameTable(
                name: "FoodCategories",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCategories_RestaurantId",
                table: "RestaurantCategory",
                newName: "IX_RestaurantCategory_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodCategories_FoodId",
                table: "Categories",
                newName: "IX_Categories_FoodId");

            migrationBuilder.AlterColumn<long>(
                name: "PromotionId",
                table: "Food",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantCategory",
                table: "RestaurantCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Food_FoodId",
                table: "Categories",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Promotions_PromotionId",
                table: "Food",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategory_Restaurants_RestaurantId",
                table: "RestaurantCategory",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

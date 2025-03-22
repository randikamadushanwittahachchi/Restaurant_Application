using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Dish_DishId",
                table: "DishIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Ingredient_IngredientId",
                table: "DishIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredient",
                table: "DishIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish",
                table: "Dish");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "DishIngredient",
                newName: "DishIngredients");

            migrationBuilder.RenameTable(
                name: "Dish",
                newName: "Dishes");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredient_IngredientId",
                table: "DishIngredients",
                newName: "IX_DishIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.RenameTable(
                name: "DishIngredients",
                newName: "DishIngredient");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Dish");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredient",
                newName: "IX_DishIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredient",
                table: "DishIngredient",
                columns: new[] { "DishId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish",
                table: "Dish",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Dish_DishId",
                table: "DishIngredient",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Ingredient_IngredientId",
                table: "DishIngredient",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vesuvius_MDT.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addons",
                columns: new[] { "AddonId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Pepperoni", 9.99m },
                    { 2, "Salad", 5.00m },
                    { 3, "Cheese", 6.00m }
                });

            migrationBuilder.InsertData(
                table: "FoodCategories",
                columns: new[] { "FoodCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "FoodStatuses",
                columns: new[] { "FoodStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "In progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "FoodCategoryId", "InStock", "Name", "Price" },
                values: new object[] { 1, "Bøf af hakket oksekød i briochebolle med salat, pickles, tomat, syltede rødløg og burgerdressing.", 1, true, "Vesuvius Burger", 139m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addons",
                keyColumn: "AddonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addons",
                keyColumn: "AddonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addons",
                keyColumn: "AddonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "FoodCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodStatuses",
                keyColumn: "FoodStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodStatuses",
                keyColumn: "FoodStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodStatuses",
                keyColumn: "FoodStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "FoodCategoryId",
                keyValue: 1);
        }
    }
}

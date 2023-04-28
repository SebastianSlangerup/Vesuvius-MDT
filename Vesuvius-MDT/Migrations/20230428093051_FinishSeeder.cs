using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vesuvius_MDT.Migrations
{
    /// <inheritdoc />
    public partial class FinishSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "marsmanden1@gmail.com", "Sebastian Møller", "4528994940" },
                    { 2, "mart377i@gmail.com", "Martin Egeskov", "4511223344" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Chef" }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "LoginId", "Password", "Username" },
                values: new object[] { 1, "Admin2023", "TestUser" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1,
                column: "FoodCategoryId",
                value: 2);

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "OrderStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "In Progress" },
                    { 2, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Location", "TableSize" },
                values: new object[,]
                {
                    { 1, "Zone 3", 2 },
                    { 2, "Zone 3", 4 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmailAdress", "EmployeeName", "EmployeeTypeId", "LoginId", "PhoneNumber" },
                values: new object[] { 1, "marsmanden1@gmail.com", "Sebastian Møller", 1, 1, 28994940 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "CustomerRefId", "Extra", "ReservationDateTime", "ResevationEnd", "ResevationStart", "TableId" },
                values: new object[] { 1, null, 1, "Plads til handikap, tak :)", new DateTime(2023, 4, 28, 11, 30, 51, 651, DateTimeKind.Local).AddTicks(3160), new DateTime(2023, 4, 28, 16, 30, 51, 651, DateTimeKind.Local).AddTicks(3210), new DateTime(2023, 4, 28, 12, 30, 51, 651, DateTimeKind.Local).AddTicks(3200), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderStatusId", "ReservationId", "ServerId", "Tips" },
                values: new object[] { 1, 1, 1, 1, 1, 2.50m });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "Count", "Discount", "FoodStatusId", "MenuItemId", "OrderId", "Paid" },
                values: new object[] { 1, 2, null, 1, 1, 1, 140.99m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "EmployeeTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "EmployeeTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Logins",
                keyColumn: "LoginId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1,
                column: "FoodCategoryId",
                value: 1);
        }
    }
}

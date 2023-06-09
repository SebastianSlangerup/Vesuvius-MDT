using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vesuvius_MDT.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomerRelationshipFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CustomerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "ReservationDateTime", "ResevationEnd", "ResevationStart" },
                values: new object[] { new DateTime(2023, 6, 8, 11, 22, 40, 992, DateTimeKind.Local).AddTicks(4320), new DateTime(2023, 6, 8, 16, 22, 40, 992, DateTimeKind.Local).AddTicks(4370), new DateTime(2023, 6, 8, 12, 22, 40, 992, DateTimeKind.Local).AddTicks(4370) });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CustomerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "ReservationDateTime", "ResevationEnd", "ResevationStart" },
                values: new object[] { new DateTime(2023, 6, 8, 11, 8, 16, 306, DateTimeKind.Local).AddTicks(4360), new DateTime(2023, 6, 8, 16, 8, 16, 306, DateTimeKind.Local).AddTicks(4410), new DateTime(2023, 6, 8, 12, 8, 16, 306, DateTimeKind.Local).AddTicks(4400) });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

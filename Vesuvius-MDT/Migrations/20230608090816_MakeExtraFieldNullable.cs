using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vesuvius_MDT.Migrations
{
    /// <inheritdoc />
    public partial class MakeExtraFieldNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Extra",
                table: "Reservations",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "ReservationDateTime", "ResevationEnd", "ResevationStart" },
                values: new object[] { new DateTime(2023, 6, 8, 11, 8, 16, 306, DateTimeKind.Local).AddTicks(4360), new DateTime(2023, 6, 8, 16, 8, 16, 306, DateTimeKind.Local).AddTicks(4410), new DateTime(2023, 6, 8, 12, 8, 16, 306, DateTimeKind.Local).AddTicks(4400) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Extra",
                table: "Reservations",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "ReservationDateTime", "ResevationEnd", "ResevationStart" },
                values: new object[] { new DateTime(2023, 6, 7, 13, 7, 0, 863, DateTimeKind.Local).AddTicks(8160), new DateTime(2023, 6, 7, 18, 7, 0, 863, DateTimeKind.Local).AddTicks(8200), new DateTime(2023, 6, 7, 14, 7, 0, 863, DateTimeKind.Local).AddTicks(8200) });
        }
    }
}

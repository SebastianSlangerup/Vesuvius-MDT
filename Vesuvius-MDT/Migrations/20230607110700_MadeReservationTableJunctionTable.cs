using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vesuvius_MDT.Migrations
{
    /// <inheritdoc />
    public partial class MadeReservationTableJunctionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservationTable",
                columns: table => new
                {
                    ReservationsReservationId = table.Column<int>(type: "int", nullable: false),
                    TablesTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTable", x => new { x.ReservationsReservationId, x.TablesTableId });
                    table.ForeignKey(
                        name: "FK_ReservationTable_Reservations_ReservationsReservationId",
                        column: x => x.ReservationsReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationTable_Tables_TablesTableId",
                        column: x => x.TablesTableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "LoginId",
                keyValue: 1,
                columns: new[] { "AccessToken", "RefreshToken" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "ReservationDateTime", "ResevationEnd", "ResevationStart" },
                values: new object[] { new DateTime(2023, 6, 7, 13, 7, 0, 863, DateTimeKind.Local).AddTicks(8160), new DateTime(2023, 6, 7, 18, 7, 0, 863, DateTimeKind.Local).AddTicks(8200), new DateTime(2023, 6, 7, 14, 7, 0, 863, DateTimeKind.Local).AddTicks(8200) });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTable_TablesTableId",
                table: "ReservationTable",
                column: "TablesTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationTable");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Logins");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "ReservationDateTime", "ResevationEnd", "ResevationStart", "TableId" },
                values: new object[] { new DateTime(2023, 6, 1, 13, 59, 56, 437, DateTimeKind.Local).AddTicks(420), new DateTime(2023, 6, 1, 18, 59, 56, 437, DateTimeKind.Local).AddTicks(470), new DateTime(2023, 6, 1, 14, 59, 56, 437, DateTimeKind.Local).AddTicks(460), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "TableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

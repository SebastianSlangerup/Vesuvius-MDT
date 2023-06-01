using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vesuvius_MDT.Migrations
{
    /// <inheritdoc />
    public partial class MadeJunctionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddonLinks");

            migrationBuilder.CreateTable(
                name: "AddonOrderItem",
                columns: table => new
                {
                    AddonsAddonId = table.Column<int>(type: "int", nullable: false),
                    OrderItemsOrderItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddonOrderItem", x => new { x.AddonsAddonId, x.OrderItemsOrderItemId });
                    table.ForeignKey(
                        name: "FK_AddonOrderItem_Addons_AddonsAddonId",
                        column: x => x.AddonsAddonId,
                        principalTable: "Addons",
                        principalColumn: "AddonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddonOrderItem_OrderItems_OrderItemsOrderItemId",
                        column: x => x.OrderItemsOrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "ReservationDateTime", "ResevationEnd", "ResevationStart" },
                values: new object[] { new DateTime(2023, 6, 1, 13, 59, 56, 437, DateTimeKind.Local).AddTicks(420), new DateTime(2023, 6, 1, 18, 59, 56, 437, DateTimeKind.Local).AddTicks(470), new DateTime(2023, 6, 1, 14, 59, 56, 437, DateTimeKind.Local).AddTicks(460) });

            migrationBuilder.CreateIndex(
                name: "IX_AddonOrderItem_OrderItemsOrderItemId",
                table: "AddonOrderItem",
                column: "OrderItemsOrderItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddonOrderItem");

            migrationBuilder.CreateTable(
                name: "AddonLinks",
                columns: table => new
                {
                    AddonLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddonId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddonLinks", x => x.AddonLinkId);
                    table.ForeignKey(
                        name: "FK_AddonLinks_Addons_AddonId",
                        column: x => x.AddonId,
                        principalTable: "Addons",
                        principalColumn: "AddonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddonLinks_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "ReservationDateTime", "ResevationEnd", "ResevationStart" },
                values: new object[] { new DateTime(2023, 4, 28, 11, 30, 51, 651, DateTimeKind.Local).AddTicks(3160), new DateTime(2023, 4, 28, 16, 30, 51, 651, DateTimeKind.Local).AddTicks(3210), new DateTime(2023, 4, 28, 12, 30, 51, 651, DateTimeKind.Local).AddTicks(3200) });

            migrationBuilder.CreateIndex(
                name: "IX_AddonLinks_AddonId",
                table: "AddonLinks",
                column: "AddonId");

            migrationBuilder.CreateIndex(
                name: "IX_AddonLinks_OrderItemId",
                table: "AddonLinks",
                column: "OrderItemId");
        }
    }
}

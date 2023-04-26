using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vesuvius_MDT.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderItemId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_AddonLinks_AddonLinkId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_AddonLinkId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "AddonLinkId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "AddonLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AddonLinks_OrderItemId",
                table: "AddonLinks",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddonLinks_OrderItems_OrderItemId",
                table: "AddonLinks",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "OrderItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddonLinks_OrderItems_OrderItemId",
                table: "AddonLinks");

            migrationBuilder.DropIndex(
                name: "IX_AddonLinks_OrderItemId",
                table: "AddonLinks");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "AddonLinks");

            migrationBuilder.AddColumn<int>(
                name: "AddonLinkId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AddonLinkId",
                table: "OrderItems",
                column: "AddonLinkId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_AddonLinks_AddonLinkId",
                table: "OrderItems",
                column: "AddonLinkId",
                principalTable: "AddonLinks",
                principalColumn: "AddonLinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

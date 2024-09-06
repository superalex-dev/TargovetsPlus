using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargovetsPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixprimarykeysnamingconventions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TransactionItemId",
                table: "TransactionItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Shops",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "Notifications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InventoryLogId",
                table: "InventoryLogs",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transactions",
                newName: "TransactionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TransactionItems",
                newName: "TransactionItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shops",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notifications",
                newName: "NotificationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InventoryLogs",
                newName: "InventoryLogId");
        }
    }
}

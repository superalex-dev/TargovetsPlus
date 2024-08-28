using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargovetsPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAge",
                table: "Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerAge",
                table: "Sales",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

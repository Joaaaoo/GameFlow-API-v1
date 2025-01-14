using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGameProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityAvailable",
                table: "Games",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Games",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AvailabilityType",
                table: "Games",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableForRent",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableForSale",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailableForRent",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "IsAvailableForSale",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Games",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Games",
                newName: "QuantityAvailable");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Games",
                newName: "AvailabilityType");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGameAndRentalInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Rentals",
                newName: "RentalDate");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "Rentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Occurrence",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalEndDate",
                table: "Rentals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AditionalInformation",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GameTime",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MinAge",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberOfPlayers",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ClientId",
                table: "Rentals",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_GameId",
                table: "Rentals",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Clients_ClientId",
                table: "Rentals",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Games_GameId",
                table: "Rentals",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Clients_ClientId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Games_GameId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_ClientId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_GameId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Occurrence",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalEndDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "AditionalInformation",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MinAge",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NumberOfPlayers",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "RentalDate",
                table: "Rentals",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

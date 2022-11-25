using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GooseGame.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Normalizing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameWon",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AmountOfPlayers",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Games",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "DatePlayed",
                table: "Games",
                newName: "CreatedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Games",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Games",
                newName: "DatePlayed");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "GameWon",
                table: "Players",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfPlayers",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GooseGame.DAL.Migrations
{
    /// <inheritdoc />
    public partial class tussentabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_GameId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "Games",
                newName: "WinnerPlayerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Games",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinnerId",
                table: "Games",
                newName: "IX_Games_WinnerPlayerId");

            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PlayerGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_GameId",
                table: "PlayerGame",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinnerPlayerId",
                table: "Games",
                column: "WinnerPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinnerPlayerId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Players",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WinnerPlayerId",
                table: "Games",
                newName: "WinnerId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Games",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinnerPlayerId",
                table: "Games",
                newName: "IX_Games_WinnerId");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MauiHangmanGames.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    playerid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    level = table.Column<string>(type: "text", nullable: false),
                    scoreactuel = table.Column<int>(type: "integer", nullable: false),
                    meilleurscore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.playerid);
                });

            migrationBuilder.CreateTable(
                name: "words",
                columns: table => new
                {
                    wordid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    categoryid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_words", x => x.wordid);
                    table.ForeignKey(
                        name: "FK_words_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    gameid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    motadeviner = table.Column<string>(type: "text", nullable: false),
                    etatpendu = table.Column<int>(type: "integer", nullable: false),
                    LettresDevinees = table.Column<List<char>>(type: "character(1)[]", nullable: false),
                    nombredevies = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    gamemode = table.Column<string>(type: "text", nullable: false),
                    dateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.gameid);
                    table.ForeignKey(
                        name: "FK_games_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "playerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "leaderboard_entries",
                columns: table => new
                {
                    leaderboardentryid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    playerid = table.Column<int>(type: "integer", nullable: false),
                    playername = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    dateachieved = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaderboard_entries", x => x.leaderboardentryid);
                    table.ForeignKey(
                        name: "FK_leaderboard_entries_players_playerid",
                        column: x => x.playerid,
                        principalTable: "players",
                        principalColumn: "playerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attempts",
                columns: table => new
                {
                    attemptid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gameid = table.Column<int>(type: "integer", nullable: false),
                    playerid = table.Column<int>(type: "integer", nullable: false),
                    letter = table.Column<char>(type: "character(1)", nullable: false),
                    isgood = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attempts", x => x.attemptid);
                    table.ForeignKey(
                        name: "FK_attempts_games_gameid",
                        column: x => x.gameid,
                        principalTable: "games",
                        principalColumn: "gameid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attempts_players_playerid",
                        column: x => x.playerid,
                        principalTable: "players",
                        principalColumn: "playerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryid", "name" },
                values: new object[,]
                {
                    { 1, "Animaux" },
                    { 2, "Pays" },
                    { 3, "Science" }
                });

            migrationBuilder.InsertData(
                table: "words",
                columns: new[] { "wordid", "categoryid", "text" },
                values: new object[,]
                {
                    { 1, 1, "Lion" },
                    { 2, 1, "Tigre" },
                    { 3, 2, "France" },
                    { 4, 2, "Brésil" },
                    { 5, 3, "Atome" },
                    { 6, 3, "Molecule" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_attempts_gameid",
                table: "attempts",
                column: "gameid");

            migrationBuilder.CreateIndex(
                name: "IX_attempts_playerid",
                table: "attempts",
                column: "playerid");

            migrationBuilder.CreateIndex(
                name: "IX_games_PlayerId",
                table: "games",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_leaderboard_entries_playerid",
                table: "leaderboard_entries",
                column: "playerid");

            migrationBuilder.CreateIndex(
                name: "IX_words_categoryid",
                table: "words",
                column: "categoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attempts");

            migrationBuilder.DropTable(
                name: "leaderboard_entries");

            migrationBuilder.DropTable(
                name: "words");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}

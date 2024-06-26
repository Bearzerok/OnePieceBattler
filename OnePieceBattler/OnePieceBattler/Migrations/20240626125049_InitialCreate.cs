using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnePieceBattler.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackPower = table.Column<int>(type: "INTEGER", nullable: false),
                    DefensePower = table.Column<int>(type: "INTEGER", nullable: false),
                    ArmamentHakiPower = table.Column<int>(type: "INTEGER", nullable: false),
                    ObservationHakiPower = table.Column<int>(type: "INTEGER", nullable: false),
                    ConquerorHakiPower = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Player1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Player2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Player1Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Player2Health = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPlayer1Turn = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsBattleOver = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Characters_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Battles_Characters_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MovePower = table.Column<int>(type: "INTEGER", nullable: false),
                    BattleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ArmamentHakiPower", "AttackPower", "ConquerorHakiPower", "DefensePower", "Description", "Health", "ImagePath", "Name", "ObservationHakiPower" },
                values: new object[,]
                {
                    { 1, 0, 20, 0, 10, "Monkey D. Luffy", 100, "/images/characters/luffy.png", "Luffy", 0 },
                    { 2, 0, 0, 0, 10, "Zoro the Pirate Hunter", 200, "/images/characters/zoro.png", "Zoro", 0 },
                    { 3, 0, 20, 0, 10, "Marco the Phoenix, Hybrid From", 100, "/images/characters/marco_hybrid.png", "Marco", 0 },
                    { 4, 0, 0, 0, 10, "Gol D. Roger, The Pirate King", 200, "/images/characters/roger.png", "Gol D. Roger", 0 },
                    { 5, 0, 20, 0, 10, "Heavenly Yaksha", 100, "/images/characters/doflamingo.png", "Donquixote Doflaming", 0 },
                    { 6, 0, 0, 0, 10, "Marco the Phoenix, Zoan Form", 200, "/images/characters/marco_zoan.png", "Marco", 0 }
                });

            migrationBuilder.InsertData(
                table: "Moves",
                columns: new[] { "Id", "BattleId", "MovePower", "Name" },
                values: new object[,]
                {
                    { 1, null, 10, "Punch" },
                    { 2, null, 20, "Slash" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_Player1Id",
                table: "Battles",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_Player2Id",
                table: "Battles",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_BattleId",
                table: "Moves",
                column: "BattleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}

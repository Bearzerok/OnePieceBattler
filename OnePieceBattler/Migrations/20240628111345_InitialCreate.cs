using System;
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
                name: "Islands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Climate = table.Column<int>(type: "INTEGER", nullable: false),
                    Terrain = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    IsDiscoveredByCharacter = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    CrewCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    CargoCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<double>(type: "REAL", nullable: false),
                    Durability = table.Column<double>(type: "REAL", nullable: false),
                    CurrentDurability = table.Column<double>(type: "REAL", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    IsSunk = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IslandIvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IslandId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslandIvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IslandIvents_Islands_IslandId",
                        column: x => x.IslandId,
                        principalTable: "Islands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    ShipId = table.Column<int>(type: "INTEGER", nullable: true),
                    IslandId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinates_Islands_IslandId",
                        column: x => x.IslandId,
                        principalTable: "Islands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coordinates_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShipUpgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectValue = table.Column<double>(type: "REAL", nullable: false),
                    ShipId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipUpgrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipUpgrades_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShipWeapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Damage = table.Column<double>(type: "REAL", nullable: false),
                    Range = table.Column<double>(type: "REAL", nullable: false),
                    AmmoCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentAmmo = table.Column<int>(type: "INTEGER", nullable: false),
                    ShipId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipWeapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipWeapons_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id");
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
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MovePower = table.Column<int>(type: "INTEGER", nullable: false),
                    SelfDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveAccuracy = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveType = table.Column<string>(type: "TEXT", nullable: true),
                    MovePriority = table.Column<bool>(type: "INTEGER", nullable: false),
                    MoveCooldown = table.Column<int>(type: "INTEGER", nullable: false),
                    Effect = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfTargets = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfHits = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveLuck = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveCriticalHitChance = table.Column<int>(type: "INTEGER", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CharacterMove",
                columns: table => new
                {
                    MoveExclusiveCharactersId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMove", x => new { x.MoveExclusiveCharactersId, x.MovesId });
                    table.ForeignKey(
                        name: "FK_CharacterMove_Moves_MovesId",
                        column: x => x.MovesId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    CriticalAttackMultiplier = table.Column<int>(type: "INTEGER", nullable: false),
                    DefensePower = table.Column<int>(type: "INTEGER", nullable: false),
                    ArmamentHakiPower = table.Column<int>(type: "INTEGER", nullable: false),
                    ObservationHakiPower = table.Column<int>(type: "INTEGER", nullable: false),
                    ConquerorHakiPower = table.Column<int>(type: "INTEGER", nullable: false),
                    DevilFruit = table.Column<string>(type: "TEXT", nullable: true),
                    DevilFruitType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAwakened = table.Column<bool>(type: "INTEGER", nullable: true),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    BattleIq = table.Column<int>(type: "INTEGER", nullable: false),
                    Luck = table.Column<int>(type: "INTEGER", nullable: false),
                    Bounty = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Experience = table.Column<int>(type: "INTEGER", nullable: false),
                    Gold = table.Column<float>(type: "REAL", nullable: false),
                    ExperienceToNextLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    ExperienceToNextLevelBase = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDefeated = table.Column<bool>(type: "INTEGER", nullable: false),
                    CrewName = table.Column<string>(type: "TEXT", nullable: true),
                    CrewRole = table.Column<string>(type: "TEXT", nullable: true),
                    JollyRogerImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    CharacterVersion = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDefinitiveVersion = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPlayable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMaxLevel = table.Column<bool>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: true),
                    IslandId = table.Column<int>(type: "INTEGER", nullable: true),
                    QuestCharactersId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShipId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Islands_IslandId",
                        column: x => x.IslandId,
                        principalTable: "Islands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExperienceReward = table.Column<int>(type: "INTEGER", nullable: false),
                    GoldReward = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    PrerequisiteQuest = table.Column<string>(type: "TEXT", nullable: true),
                    StoryLine = table.Column<string>(type: "TEXT", nullable: true),
                    RequiredLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    IsRepeatable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: true),
                    IslandId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quests_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quests_Islands_IslandId",
                        column: x => x.IslandId,
                        principalTable: "Islands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Effect = table.Column<string>(type: "TEXT", nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: true),
                    IslandId = table.Column<int>(type: "INTEGER", nullable: true),
                    QuestId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShipId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Islands_IslandId",
                        column: x => x.IslandId,
                        principalTable: "Islands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestCharacters",
                columns: table => new
                {
                    QuestCharactersId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestCharacters", x => x.QuestCharactersId);
                    table.ForeignKey(
                        name: "FK_QuestCharacters_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuestId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestLog_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    TargetId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentProgress = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredProgress = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuestId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestObjectives_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    QuestId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestCharacter_Receivers",
                columns: table => new
                {
                    QuestCharactersId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestReceiversId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestCharacter_Receivers", x => new { x.QuestCharactersId, x.QuestReceiversId });
                    table.ForeignKey(
                        name: "FK_QuestCharacter_Receivers_Characters_QuestReceiversId",
                        column: x => x.QuestReceiversId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestCharacter_Receivers_QuestCharacters_QuestCharactersId",
                        column: x => x.QuestCharactersId,
                        principalTable: "QuestCharacters",
                        principalColumn: "QuestCharactersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ArmamentHakiPower", "AttackPower", "BattleIq", "Bounty", "CharacterId", "CharacterVersion", "ConquerorHakiPower", "CrewName", "CrewRole", "CriticalAttackMultiplier", "DefensePower", "Description", "DevilFruit", "DevilFruitType", "Experience", "ExperienceToNextLevel", "ExperienceToNextLevelBase", "Gold", "Health", "ImagePath", "IsAwakened", "IsDefeated", "IsDefinitiveVersion", "IsMaxLevel", "IsPlayable", "IslandId", "JollyRogerImagePath", "Level", "Luck", "Name", "ObservationHakiPower", "QuestCharactersId", "ShipId", "Speed" },
                values: new object[,]
                {
                    { 1, 0, 20, 0, 0, null, 0, 0, null, null, 0, 10, "Monkey D. Luffy", null, 0, 0, 0, 0, 0f, 100, "/images/characters/luffy.png", null, false, 0, false, false, null, null, 0, 0, "Luffy", 0, null, null, 0 },
                    { 2, 0, 0, 0, 0, null, 0, 0, null, null, 0, 10, "Zoro the Pirate Hunter", null, 0, 0, 0, 0, 0f, 200, "/images/characters/zoro.png", null, false, 0, false, false, null, null, 0, 0, "Zoro", 0, null, null, 0 },
                    { 3, 0, 20, 0, 0, null, 0, 0, null, null, 0, 10, "Marco the Phoenix, Hybrid From", null, 0, 0, 0, 0, 0f, 100, "/images/characters/marco_hybrid.png", null, false, 0, false, false, null, null, 0, 0, "Marco", 0, null, null, 0 },
                    { 4, 0, 0, 0, 0, null, 0, 0, null, null, 0, 10, "Gol D. Roger, The Pirate King", null, 0, 0, 0, 0, 0f, 200, "/images/characters/roger.png", null, false, 0, false, false, null, null, 0, 0, "Gol D. Roger", 0, null, null, 0 },
                    { 5, 0, 20, 0, 0, null, 0, 0, null, null, 0, 10, "Heavenly Yaksha", null, 0, 0, 0, 0, 0f, 100, "/images/characters/doflamingo.png", null, false, 0, false, false, null, null, 0, 0, "Donquixote Doflaming", 0, null, null, 0 },
                    { 6, 0, 0, 0, 0, null, 0, 0, null, null, 0, 10, "Marco the Phoenix, Zoan Form", null, 0, 0, 0, 0, 0f, 200, "/images/characters/marco_zoan.png", null, false, 0, false, false, null, null, 0, 0, "Marco", 0, null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Moves",
                columns: new[] { "Id", "BattleId", "Effect", "ImagePath", "MoveAccuracy", "MoveCooldown", "MoveCriticalHitChance", "MoveLuck", "MovePower", "MovePriority", "MoveType", "Name", "NumberOfHits", "NumberOfTargets", "SelfDamage" },
                values: new object[,]
                {
                    { 1, null, null, null, 0, 0, 0, 0, 10, false, null, "Punch", 0, 0, 0 },
                    { 2, null, null, null, 0, 0, 0, 0, 20, false, null, "Slash", 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Quests",
                columns: new[] { "Id", "CharacterId", "Description", "EndTime", "ExperienceReward", "GoldReward", "IsRepeatable", "IslandId", "Location", "PrerequisiteQuest", "RequiredLevel", "StartTime", "Status", "StoryLine", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Embark on a journey to find the legendary One Piece treasure.", null, 0, 0, false, null, null, null, 0, null, 0, null, "Find the One Piece", 0 },
                    { 2, 2, "Train with the world's greatest swordsman to improve sword skills.", null, 0, 0, false, null, null, null, 0, null, 0, null, "Train with Mihawk", 0 }
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
                name: "IX_CharacterMove_MovesId",
                table: "CharacterMove",
                column: "MovesId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterId",
                table: "Characters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_IslandId",
                table: "Characters",
                column: "IslandId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_QuestCharactersId",
                table: "Characters",
                column: "QuestCharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ShipId",
                table: "Characters",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_IslandId",
                table: "Coordinates",
                column: "IslandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_ShipId",
                table: "Coordinates",
                column: "ShipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IslandIvents_IslandId",
                table: "IslandIvents",
                column: "IslandId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharacterId",
                table: "Items",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_IslandId",
                table: "Items",
                column: "IslandId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_QuestId",
                table: "Items",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShipId",
                table: "Items",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_BattleId",
                table: "Moves",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestCharacter_Receivers_QuestReceiversId",
                table: "QuestCharacter_Receivers",
                column: "QuestReceiversId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestCharacters_QuestId",
                table: "QuestCharacters",
                column: "QuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestLog_QuestId",
                table: "QuestLog",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestObjectives_QuestId",
                table: "QuestObjectives",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_CharacterId",
                table: "Quests",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_IslandId",
                table: "Quests",
                column: "IslandId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_QuestId",
                table: "Rewards",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipUpgrades_ShipId",
                table: "ShipUpgrades",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipWeapons_ShipId",
                table: "ShipWeapons",
                column: "ShipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Characters_Player1Id",
                table: "Battles",
                column: "Player1Id",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Characters_Player2Id",
                table: "Battles",
                column: "Player2Id",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMove_Characters_MoveExclusiveCharactersId",
                table: "CharacterMove",
                column: "MoveExclusiveCharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_QuestCharacters_QuestCharactersId",
                table: "Characters",
                column: "QuestCharactersId",
                principalTable: "QuestCharacters",
                principalColumn: "QuestCharactersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Characters_CharacterId",
                table: "Quests");

            migrationBuilder.DropTable(
                name: "CharacterMove");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "IslandIvents");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "QuestCharacter_Receivers");

            migrationBuilder.DropTable(
                name: "QuestLog");

            migrationBuilder.DropTable(
                name: "QuestObjectives");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "ShipUpgrades");

            migrationBuilder.DropTable(
                name: "ShipWeapons");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "QuestCharacters");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Islands");
        }
    }
}

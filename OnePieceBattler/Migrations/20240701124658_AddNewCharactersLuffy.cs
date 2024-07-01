using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePieceBattler.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCharactersLuffy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IslandIvents_Islands_IslandId",
                table: "IslandIvents");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestLog_Quests_QuestId",
                table: "QuestLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestLog",
                table: "QuestLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IslandIvents",
                table: "IslandIvents");

            migrationBuilder.RenameTable(
                name: "QuestLog",
                newName: "QuestLogs");

            migrationBuilder.RenameTable(
                name: "IslandIvents",
                newName: "IslandEvents");

            migrationBuilder.RenameIndex(
                name: "IX_QuestLog_QuestId",
                table: "QuestLogs",
                newName: "IX_QuestLogs_QuestId");

            migrationBuilder.RenameIndex(
                name: "IX_IslandIvents_IslandId",
                table: "IslandEvents",
                newName: "IX_IslandEvents_IslandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestLogs",
                table: "QuestLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IslandEvents",
                table: "IslandEvents",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ArmamentHakiPower", "AttackPower", "BattleIq", "Bounty", "CharacterId", "CharacterVersion", "ConquerorHakiPower", "CrewName", "CrewRole", "CriticalAttackMultiplier", "DefensePower", "Description", "DevilFruit", "DevilFruitType", "Experience", "ExperienceToNextLevel", "ExperienceToNextLevelBase", "Gold", "Health", "ImagePath", "IsAwakened", "IsDefeated", "IsDefinitiveVersion", "IsMaxLevel", "IsPlayable", "IslandId", "JollyRogerImagePath", "Level", "Luck", "Name", "ObservationHakiPower", "QuestCharactersId", "ShipId", "Speed" },
                values: new object[] { 7, 0, 20, 0, 0, null, 0, 0, null, null, 0, 10, "Monkey D. Luffy", null, 0, 0, 100, 100, 0f, 500, "/images/characters/luffy_gear_5.png", null, false, 0, false, false, null, null, 1, 10, "Luffy", 0, null, null, 10 });

            migrationBuilder.InsertData(
                table: "Moves",
                columns: new[] { "Id", "BattleId", "Effect", "ImagePath", "MoveAccuracy", "MoveCooldown", "MoveCriticalHitChance", "MoveLuck", "MovePower", "MovePriority", "MoveType", "Name", "NumberOfHits", "NumberOfTargets", "SelfDamage" },
                values: new object[] { 3, null, null, null, 0, 0, 0, 0, 100, false, null, "Kick", 0, 0, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_IslandEvents_Islands_IslandId",
                table: "IslandEvents",
                column: "IslandId",
                principalTable: "Islands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestLogs_Quests_QuestId",
                table: "QuestLogs",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IslandEvents_Islands_IslandId",
                table: "IslandEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestLogs_Quests_QuestId",
                table: "QuestLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestLogs",
                table: "QuestLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IslandEvents",
                table: "IslandEvents");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "QuestLogs",
                newName: "QuestLog");

            migrationBuilder.RenameTable(
                name: "IslandEvents",
                newName: "IslandIvents");

            migrationBuilder.RenameIndex(
                name: "IX_QuestLogs_QuestId",
                table: "QuestLog",
                newName: "IX_QuestLog_QuestId");

            migrationBuilder.RenameIndex(
                name: "IX_IslandEvents_IslandId",
                table: "IslandIvents",
                newName: "IX_IslandIvents_IslandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestLog",
                table: "QuestLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IslandIvents",
                table: "IslandIvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IslandIvents_Islands_IslandId",
                table: "IslandIvents",
                column: "IslandId",
                principalTable: "Islands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestLog_Quests_QuestId",
                table: "QuestLog",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");
        }
    }
}

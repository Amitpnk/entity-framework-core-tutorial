using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryApp.Data.Migrations
{
    public partial class modification_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MilitaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horses_Militaries_MilitaryId",
                        column: x => x.MilitaryId,
                        principalTable: "Militaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryBattle",
                columns: table => new
                {
                    MilitaryId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryBattle", x => new { x.MilitaryId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_MilitaryBattle_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitaryBattle_Militaries_MilitaryId",
                        column: x => x.MilitaryId,
                        principalTable: "Militaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horses_MilitaryId",
                table: "Horses",
                column: "MilitaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryBattle_BattleId",
                table: "MilitaryBattle",
                column: "BattleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "MilitaryBattle");

            migrationBuilder.DropTable(
                name: "Battles");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadiumCapacity = table.Column<int>(type: "int", nullable: false),
                    StadiumLocation = table.Column<int>(type: "int", nullable: false),
                    StadiumName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mascot = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StadiumEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_StadiumEntityId",
                        column: x => x.StadiumEntityId,
                        principalTable: "Stadiums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamAId = table.Column<int>(type: "int", nullable: false),
                    TeamBId = table.Column<int>(type: "int", nullable: false),
                    TeamEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Positions = table.Column<int>(type: "int", nullable: false),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    HomeTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamEntityId",
                table: "Games",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamEntityId",
                table: "Players",
                column: "TeamEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumEntityId",
                table: "Teams",
                column: "StadiumEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}

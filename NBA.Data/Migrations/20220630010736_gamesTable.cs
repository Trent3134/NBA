using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA.Data.Migrations
{
    public partial class gamesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamEntityId",
                table: "Games",
                column: "TeamEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}

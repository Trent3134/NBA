using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA.Data.Migrations
{
    public partial class Stadium_model_refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StadiumEntityId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StadiumLocation",
                table: "Stadiums",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumEntityId",
                table: "Teams",
                column: "StadiumEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_StadiumEntityId",
                table: "Teams",
                column: "StadiumEntityId",
                principalTable: "Stadiums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_StadiumEntityId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_StadiumEntityId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StadiumEntityId",
                table: "Teams");

            migrationBuilder.AlterColumn<string>(
                name: "StadiumLocation",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

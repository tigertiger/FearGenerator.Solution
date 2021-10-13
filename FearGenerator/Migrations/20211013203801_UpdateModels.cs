using Microsoft.EntityFrameworkCore.Migrations;

namespace FearGenerator.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Subgenres_SubgenreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_SubgenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "SubgenreId",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubgenreId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_SubgenreId",
                table: "Movies",
                column: "SubgenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Subgenres_SubgenreId",
                table: "Movies",
                column: "SubgenreId",
                principalTable: "Subgenres",
                principalColumn: "SubgenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

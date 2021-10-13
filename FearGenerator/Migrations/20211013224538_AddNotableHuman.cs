using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FearGenerator.Migrations
{
    public partial class AddNotableHuman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotableHuman",
                columns: table => new
                {
                    NotableHumanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HumanName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Roll = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotableHuman", x => x.NotableHumanId);
                });

            migrationBuilder.CreateTable(
                name: "NotableHumansMovies",
                columns: table => new
                {
                    NotableHumansMoviesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    NotableHumansId = table.Column<int>(type: "int", nullable: false),
                    NotableHumanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotableHumansMovies", x => x.NotableHumansMoviesId);
                    table.ForeignKey(
                        name: "FK_NotableHumansMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotableHumansMovies_NotableHuman_NotableHumanId",
                        column: x => x.NotableHumanId,
                        principalTable: "NotableHuman",
                        principalColumn: "NotableHumanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotableHumansMovies_MovieId",
                table: "NotableHumansMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableHumansMovies_NotableHumanId",
                table: "NotableHumansMovies",
                column: "NotableHumanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotableHumansMovies");

            migrationBuilder.DropTable(
                name: "NotableHuman");
        }
    }
}

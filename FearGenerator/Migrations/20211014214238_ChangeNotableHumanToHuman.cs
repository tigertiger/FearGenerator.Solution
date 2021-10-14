using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FearGenerator.Migrations
{
    public partial class ChangeNotableHumanToHuman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotableHumansMovies");

            migrationBuilder.DropTable(
                name: "NotableHuman");

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    HumanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HumanName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Role = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Notes = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.HumanId);
                });

            migrationBuilder.CreateTable(
                name: "HumansMovies",
                columns: table => new
                {
                    HumansMoviesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    HumanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumansMovies", x => x.HumansMoviesId);
                    table.ForeignKey(
                        name: "FK_HumansMovies_Humans_HumanId",
                        column: x => x.HumanId,
                        principalTable: "Humans",
                        principalColumn: "HumanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HumansMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HumansMovies_HumanId",
                table: "HumansMovies",
                column: "HumanId");

            migrationBuilder.CreateIndex(
                name: "IX_HumansMovies_MovieId",
                table: "HumansMovies",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HumansMovies");

            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.CreateTable(
                name: "NotableHuman",
                columns: table => new
                {
                    NotableHumanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HumanName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Notes = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Role = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
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
                    NotableHumanId = table.Column<int>(type: "int", nullable: true),
                    NotableHumansId = table.Column<int>(type: "int", nullable: false)
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
    }
}

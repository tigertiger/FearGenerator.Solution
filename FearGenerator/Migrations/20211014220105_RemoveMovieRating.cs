using Microsoft.EntityFrameworkCore.Migrations;

namespace FearGenerator.Migrations
{
    public partial class RemoveMovieRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movies",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}

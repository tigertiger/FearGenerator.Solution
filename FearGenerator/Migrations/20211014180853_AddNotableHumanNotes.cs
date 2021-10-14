using Microsoft.EntityFrameworkCore.Migrations;

namespace FearGenerator.Migrations
{
    public partial class AddNotableHumanNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "NotableHuman",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "NotableHuman");
        }
    }
}

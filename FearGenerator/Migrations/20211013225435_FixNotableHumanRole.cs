using Microsoft.EntityFrameworkCore.Migrations;

namespace FearGenerator.Migrations
{
    public partial class FixNotableHumanRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roll",
                table: "NotableHuman",
                newName: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "NotableHuman",
                newName: "Roll");
        }
    }
}

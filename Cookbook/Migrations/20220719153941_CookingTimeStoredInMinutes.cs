using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookbook.Migrations
{
    public partial class CookingTimeStoredInMinutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CookingTimeInSeconds",
                table: "Recipe",
                newName: "CookingTimeInMinutes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CookingTimeInMinutes",
                table: "Recipe",
                newName: "CookingTimeInSeconds");
        }
    }
}

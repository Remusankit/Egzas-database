using Microsoft.EntityFrameworkCore.Migrations;

namespace Egzas_Databasu.Migrations
{
    public partial class Mi_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kelintas",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kelintas",
                table: "Lectures");
        }
    }
}

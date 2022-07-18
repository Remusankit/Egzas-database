using Microsoft.EntityFrameworkCore.Migrations;

namespace Egzas_Databasu.Migrations
{
    public partial class Mi_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Iq_lygis",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iq_lygis",
                table: "Students");
        }
    }
}

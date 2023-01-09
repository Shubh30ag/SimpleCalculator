using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCalculator.Migrations
{
    public partial class InitialDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Result",
                table: "Calculations",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Calculations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCalculator.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    First_Number = table.Column<decimal>(nullable: false),
                    Second_Number = table.Column<decimal>(nullable: false),
                    Operator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.First_Number);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");
        }
    }
}

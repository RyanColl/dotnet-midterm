using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympicsWeb.Data.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Olympics");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Continent = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Season = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Year = table.Column<string>(type: "TEXT", nullable: false),
                    Opening = table.Column<string>(type: "TEXT", nullable: false),
                    Closing = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.CreateTable(
                name: "Olympics",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Closing = table.Column<string>(type: "TEXT", nullable: false),
                    Continent = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Opening = table.Column<string>(type: "TEXT", nullable: false),
                    Season = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olympics", x => x.Id);
                });
        }
    }
}

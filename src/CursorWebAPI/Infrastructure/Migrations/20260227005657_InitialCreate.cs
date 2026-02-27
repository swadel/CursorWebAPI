using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CursorWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShowDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Venue = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    FunFact = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    YouTubeUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "City", "FunFact", "ImageUrl", "ShowDate", "State", "Venue", "YouTubeUrl" },
                values: new object[,]
                {
                    { 1, "Ithaca", "Widely considered one of the greatest Grateful Dead concerts ever performed. The tape circulated for decades as a legendary bootleg.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4e/Barton_Hall_Cornell.jpg/800px-Barton_Hall_Cornell.jpg", new DateOnly(1977, 5, 8), "NY", "Barton Hall, Cornell University", "https://www.youtube.com/watch?v=jLGk3CVMdQU" },
                    { 2, "Veneta", "The iconic \"Sunshine Daydream\" show—famous for its high energy and the psychedelic film footage from the day.", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Veneta%2C_Oregon.jpg/800px-Veneta%2C_Oregon.jpg", new DateOnly(1972, 8, 27), "OR", "Old Renaissance Faire Grounds", "https://www.youtube.com/watch?v=JidgG6g1l3o" },
                    { 3, "Philadelphia", "A massive summer '89 stadium performance—often cited as a peak era for the band's late-career sound.", null, new DateOnly(1989, 7, 7), "PA", "John F. Kennedy Stadium", null },
                    { 4, "New York", "A strong late-'80s run at MSG—part of the post-\"Touch of Grey\" resurgence that brought in a new wave of fans.", null, new DateOnly(1987, 9, 18), "NY", "Madison Square Garden", null },
                    { 5, "New York", "A classic early-1970 Fillmore East set, showcasing the band as it bridged the psychedelic era into tighter songcraft.", null, new DateOnly(1970, 2, 13), "NY", "Fillmore East", null },
                    { 6, "Chicago", "The band's final concert—an emotional capstone to three decades of touring and a major point of reflection in Deadhead history.", null, new DateOnly(1995, 7, 9), "IL", "Soldier Field", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ShowDate",
                table: "Shows",
                column: "ShowDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}

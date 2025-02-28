using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoferApi.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "default");

            migrationBuilder.CreateTable(
                name: "Airport",
                schema: "default",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    ElevationFeet = table.Column<double>(type: "REAL", nullable: false),
                    Continent = table.Column<string>(type: "TEXT", nullable: false),
                    IsoCountry = table.Column<string>(type: "TEXT", nullable: false),
                    IsoRegion = table.Column<string>(type: "TEXT", nullable: false),
                    Municipality = table.Column<string>(type: "TEXT", nullable: false),
                    ScheduledService = table.Column<string>(type: "TEXT", nullable: false),
                    GpsCode = table.Column<string>(type: "TEXT", nullable: false),
                    IcaoCode = table.Column<string>(type: "TEXT", nullable: false),
                    IatoCode = table.Column<string>(type: "TEXT", nullable: false),
                    LocalCode = table.Column<string>(type: "TEXT", nullable: false),
                    WebsiteLink = table.Column<string>(type: "TEXT", nullable: false),
                    WikipediaLink = table.Column<string>(type: "TEXT", nullable: false),
                    Keywords = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airport",
                schema: "default");
        }
    }
}

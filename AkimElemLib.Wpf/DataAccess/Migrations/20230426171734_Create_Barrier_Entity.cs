using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkimElemLib.Wpf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Create_Barrier_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barrier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    HeightRelativeToGround = table.Column<double>(type: "REAL", nullable: false),
                    Width = table.Column<double>(type: "REAL", nullable: false),
                    Transparency = table.Column<double>(type: "REAL", nullable: false),
                    IsClosed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsRamResistant = table.Column<bool>(type: "INTEGER", nullable: false),
                    MinOvercomeTime = table.Column<double>(type: "REAL", nullable: false),
                    MaxOvercomeTime = table.Column<double>(type: "REAL", nullable: false),
                    IsSurmountableByResponseTeams = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrier", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barrier");
        }
    }
}

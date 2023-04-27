using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkimElemLib.Wpf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Create_Obstacle_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obstacle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    Width = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    HeightRelativeToGround = table.Column<double>(type: "REAL", nullable: false),
                    Transparency = table.Column<double>(type: "REAL", nullable: false),
                    VelocityMeasureUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxVelocity = table.Column<double>(type: "REAL", nullable: false),
                    HasBase = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAluminiumBarbedTape = table.Column<bool>(type: "INTEGER", nullable: false),
                    VisorFenceParams_IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    VisorFenceParams_Height = table.Column<double>(type: "REAL", nullable: false),
                    AntiUndercarriageDeviceParams_IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    AntiUndercarriageDeviceParams_Depth = table.Column<double>(type: "REAL", nullable: false),
                    IsRamResistant = table.Column<bool>(type: "INTEGER", nullable: false),
                    MinOvercomeTime = table.Column<double>(type: "REAL", nullable: false),
                    MaxOvercomeTime = table.Column<double>(type: "REAL", nullable: false),
                    MinEntranceDelay = table.Column<double>(type: "REAL", nullable: false),
                    MaxEntranceDelay = table.Column<double>(type: "REAL", nullable: false),
                    MinExitDelay = table.Column<double>(type: "REAL", nullable: false),
                    MaxExitDelay = table.Column<double>(type: "REAL", nullable: false),
                    IsSurmountableByResponseTeams = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obstacle", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obstacle");
        }
    }
}

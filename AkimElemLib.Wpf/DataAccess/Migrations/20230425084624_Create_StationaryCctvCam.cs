using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkimElemLib.Wpf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Create_StationaryCctvCam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StationaryCctvCam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    LightSensitivity = table.Column<double>(type: "REAL", nullable: false),
                    PowerSupplyType = table.Column<int>(type: "INTEGER", nullable: false),
                    PowerConsumptionWatts = table.Column<double>(type: "REAL", nullable: false),
                    WorkingVoltage = table.Column<double>(type: "REAL", nullable: false),
                    MatrixDiagonalHorizontal = table.Column<double>(type: "REAL", nullable: false),
                    MatrixDiagonalVertical = table.Column<double>(type: "REAL", nullable: false),
                    ImageResolutionHorizontal = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageResolutionVertical = table.Column<int>(type: "INTEGER", nullable: false),
                    VariofocalLensParams_IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    VariofocalLensParams_MinFocalLength = table.Column<double>(type: "REAL", nullable: false),
                    VariofocalLensParams_MaxFocalLength = table.Column<double>(type: "REAL", nullable: false),
                    MinTemperature = table.Column<double>(type: "REAL", nullable: false),
                    MaxTemperature = table.Column<double>(type: "REAL", nullable: false),
                    MatrixFormat = table.Column<int>(type: "INTEGER", nullable: false),
                    Omega = table.Column<double>(type: "REAL", nullable: false),
                    Phi = table.Column<double>(type: "REAL", nullable: false),
                    Alpha = table.Column<double>(type: "REAL", nullable: false),
                    AlphaMin = table.Column<double>(type: "REAL", nullable: false),
                    AlphaMax = table.Column<double>(type: "REAL", nullable: false),
                    Beta = table.Column<double>(type: "REAL", nullable: false),
                    InstallationHeight = table.Column<double>(type: "REAL", nullable: false),
                    HasVideoAnalytics = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fps = table.Column<double>(type: "REAL", nullable: false),
                    DetectionProbability = table.Column<double>(type: "REAL", nullable: false),
                    MinReactionTime = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationaryCctvCam", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationaryCctvCam");
        }
    }
}

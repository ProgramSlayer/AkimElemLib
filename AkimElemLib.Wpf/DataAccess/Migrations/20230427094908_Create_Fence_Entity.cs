using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkimElemLib.Wpf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Create_Fence_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fence",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<double>(type: "REAL", nullable: false),
                    Transparency = table.Column<double>(type: "REAL", nullable: false),
                    IsClosed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsRamResistant = table.Column<bool>(type: "INTEGER", nullable: false),
                    MinOvercomeTime = table.Column<double>(type: "REAL", nullable: false),
                    MaxOvercomeTime = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    HasBase = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAluminiumBarbedTape = table.Column<bool>(type: "INTEGER", nullable: false),
                    MainSurfaceParams_Name = table.Column<string>(type: "TEXT", nullable: false),
                    MainSurfaceParams_Height = table.Column<double>(type: "REAL", nullable: false),
                    MainSurfaceParams_Width = table.Column<double>(type: "REAL", nullable: false),
                    MainSurfaceParams_SendsVibrations = table.Column<bool>(type: "INTEGER", nullable: false),
                    TopParams_Name = table.Column<string>(type: "TEXT", nullable: false),
                    TopParams_Height = table.Column<double>(type: "REAL", nullable: false),
                    TopParams_Width = table.Column<double>(type: "REAL", nullable: false),
                    TopParams_SendsVibrations = table.Column<bool>(type: "INTEGER", nullable: false),
                    TopParams_SendsVibrationsToMainSurface = table.Column<bool>(type: "INTEGER", nullable: false),
                    BottomParams_Name = table.Column<string>(type: "TEXT", nullable: false),
                    BottomParams_Depth = table.Column<double>(type: "REAL", nullable: false),
                    BottomParams_Width = table.Column<double>(type: "REAL", nullable: false),
                    BottomParams_SendsVibrations = table.Column<bool>(type: "INTEGER", nullable: false),
                    BottomParams_SendsVibrationsToMainSurface = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fence", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fence");
        }
    }
}

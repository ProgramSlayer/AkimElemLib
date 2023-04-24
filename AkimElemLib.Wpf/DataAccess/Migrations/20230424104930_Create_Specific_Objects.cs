using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkimElemLib.Wpf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Create_Specific_Objects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecificObjectBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    VelocityMeasureUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxVelocity = table.Column<double>(type: "REAL", nullable: false),
                    Transparency = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    HeightRelativeToGround = table.Column<double>(type: "REAL", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificObjectBase", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificObjectBase");
        }
    }
}

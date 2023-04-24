using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkimElemLib.Wpf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intruder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VelocityParams_VelocityMeasureUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    VelocityParams_MinVelocity = table.Column<double>(type: "REAL", nullable: false),
                    VelocityParams_MaxVelocity = table.Column<double>(type: "REAL", nullable: false),
                    AccomplicesParams_HasAccomplices = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccomplicesParams_Iso2xDelayDropProbability = table.Column<double>(type: "REAL", nullable: false),
                    AccomplicesParams_Sensors2xDetectionDecreaseProbability = table.Column<double>(type: "REAL", nullable: false),
                    AccomplicesParams_TimeTillIntentionalFalseAlarm = table.Column<double>(type: "REAL", nullable: false),
                    CarParams_HasCar = table.Column<bool>(type: "INTEGER", nullable: false),
                    CarParams_VelocityIncreaseCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    CarParams_CarDropProbability = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_UnnoticedIntrusionProbability = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_CautionDropTo0Probability = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_IntrusionRefusalProbability = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_VelocityChangeProbability = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_VelocityIncreaseProbability = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_MovementDirectionChangeProbability = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_MinRunawayDistance = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_MaxRunawayDistance = table.Column<double>(type: "REAL", nullable: false),
                    PsychophysicalParams_ObjectTerritoryKnowledgePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    PsychophysicalParams_AerialConstructionIntrusionProbability = table.Column<double>(type: "REAL", nullable: false),
                    LightEquipment_IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    LightEquipment_ObstacleOvercomeTimeDecreaseCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    LightEquipment_VelocityDecreaseCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    MediumEquipment_IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    MediumEquipment_ObstacleOvercomeTimeDecreaseCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    MediumEquipment_VelocityDecreaseCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    HeavyEquipment_IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    HeavyEquipment_ObstacleOvercomeTimeDecreaseCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    HeavyEquipment_VelocityDecreaseCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    DropEquipmentProbability = table.Column<double>(type: "REAL", nullable: false),
                    LengthParams_FullHeightMm = table.Column<int>(type: "INTEGER", nullable: false),
                    LengthParams_DeepSquatMm = table.Column<int>(type: "INTEGER", nullable: false),
                    LengthParams_CrawlingMm = table.Column<int>(type: "INTEGER", nullable: false),
                    HeightParams_FullHeightMm = table.Column<int>(type: "INTEGER", nullable: false),
                    HeightParams_DeepSquatMm = table.Column<int>(type: "INTEGER", nullable: false),
                    HeightParams_CrawlingMm = table.Column<int>(type: "INTEGER", nullable: false),
                    WidthParams_FullHeightMm = table.Column<int>(type: "INTEGER", nullable: false),
                    WidthParams_DeepSquatMm = table.Column<int>(type: "INTEGER", nullable: false),
                    WidthParams_CrawlingMm = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intruder", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intruder");
        }
    }
}

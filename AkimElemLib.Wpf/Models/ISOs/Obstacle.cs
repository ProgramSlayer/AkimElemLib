using AkimElemLib.Wpf.Models.Common;
using System;

namespace AkimElemLib.Wpf.Models.ISOs;

public class Obstacle
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required double Length { get; set; }
    public required double Width { get; set; }
    public required double Height { get; set; }
    public required double HeightRelativeToGround { get; set; }
    public required double Transparency { get; set; }
    public required VelocityMeasureUnits VelocityMeasureUnit { get; set; }
    public required double MaxVelocity { get; set; }
    // Цоколь
    public required bool HasBase { get; set; }
    // Алюминиевая колючая лента
    public required bool HasAluminiumBarbedTape { get; set; }
    // Козырьковое ограждение
    public required ObstacleVisorFenceParams VisorFenceParams { get; set; }
    // Противоподкопное устройство
    public required ObstacleAntiUndercarriageDeviceParams AntiUndercarriageDeviceParams { get; set; }
    // Тараноустойчивость
    public required bool IsRamResistant { get; set; }
    public required double MinOvercomeTime { get; set; }
    public required double MaxOvercomeTime { get; set; }
    public required double MinEntranceDelay { get; set; }
    public required double MaxEntranceDelay { get; set; }
    public required double MinExitDelay { get; set; }
    public required double MaxExitDelay { get; set; }
    // Преодолимость для групп реагирования
    public required bool IsSurmountableByResponseTeams { get; set; }
}

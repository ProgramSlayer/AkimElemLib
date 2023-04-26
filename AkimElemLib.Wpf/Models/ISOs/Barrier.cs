using System;

namespace AkimElemLib.Wpf.Models.ISOs;

public class Barrier
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required double Height { get; set; }
    public required double HeightRelativeToGround { get; set; }
    public required double Width { get; set; }
    public required double Transparency { get; set; }
    // Замкнутость
    public required bool IsClosed { get; set; }
    // Тараноустойчивость
    public required bool IsRamResistant { get; set; }
    public required double MinOvercomeTime { get; set; }
    public required double MaxOvercomeTime { get; set; }
    // Преодолимость для групп реагирования
    public required bool IsSurmountableByResponseTeams { get; set; }
}

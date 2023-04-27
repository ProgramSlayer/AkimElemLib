using System;

namespace AkimElemLib.Wpf.Models.ISOs;

public class Fence
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required double Width { get; set; }
    public required double Transparency { get; set; }
    // Замкнутость
    public required bool IsClosed { get; set; }
    // Тараноустойчивость
    public required bool IsRamResistant { get; set; }
    public required double MinOvercomeTime { get; set; }
    public required double MaxOvercomeTime { get; set; }
    public required double Height { get; set; }
    // Цоколь
    public required bool HasBase { get; set; }
    // Алюминиевая колючая лента
    public required bool HasAluminiumBarbedTape { get; set; }
    // Основное полотно
    public required FenceMainSurfaceParams MainSurfaceParams { get; set; }
    // Верхнее ограждение
    public required FenceTopParams TopParams { get; set; }
    // Нижнее ограждение
    public required FenceBottomParams BottomParams { get; set; }
}

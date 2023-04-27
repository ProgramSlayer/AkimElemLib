using AkimElemLib.Wpf.Models.Common;
using AkimElemLib.Wpf.Models.ISOs;
using System;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Obstacles;

public class ObstacleReadOnlyViewModel : ViewModelBase
{
    private readonly Obstacle _obstacle;

    public ObstacleReadOnlyViewModel(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle, nameof(obstacle));
        _obstacle = obstacle;
    }

    public Guid Id => _obstacle.Id;
    public string Name => _obstacle.Name;
    public double Length => _obstacle.Length;
    public double Width => _obstacle.Width;
    public double Height => _obstacle.Height;
    public double HeightRelativeToGround => _obstacle.HeightRelativeToGround;
    public double Transparency => _obstacle.Transparency;
    public VelocityMeasureUnits VelocityMeasureUnit => _obstacle.VelocityMeasureUnit;
    public double MaxVelocity => _obstacle.MaxVelocity;
    public bool HasBase => _obstacle.HasBase;
    public bool HasAluminiumBarbedTape => _obstacle.HasAluminiumBarbedTape;
    public string VisorFenceParams => _obstacle.VisorFenceParams.ToString();
    public string AntiUndercarriageDeviceParams => _obstacle.AntiUndercarriageDeviceParams.ToString();
    public bool IsRamResistant => _obstacle.IsRamResistant;
    public double MinOvercomeTime => _obstacle.MinOvercomeTime;
    public double MaxOvercomeTime => _obstacle.MaxOvercomeTime;
    public double MinEntranceDelay => _obstacle.MinEntranceDelay;
    public double MaxEntranceDelay => _obstacle.MaxEntranceDelay;
    public double MinExitDelay => _obstacle.MinExitDelay;
    public double MaxExitDelay => _obstacle.MaxExitDelay;
    public bool IsSurmountableByResponseTeams => _obstacle.IsSurmountableByResponseTeams;
}

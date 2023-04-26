using AkimElemLib.Wpf.Models.ISOs;
using System;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Barriers;

public class BarrierReadOnlyViewModel : ViewModelBase
{
    private readonly Barrier _barrier;

    public BarrierReadOnlyViewModel(Barrier barrier)
    {
        ArgumentNullException.ThrowIfNull(barrier, nameof(barrier));
        _barrier = barrier;
    }

    public Guid Id => _barrier.Id;
    public string Name => _barrier.Name;
    public double Height => _barrier.Height;
    public double HeightRelativeToGround => _barrier.HeightRelativeToGround;
    public double Width => _barrier.Width;
    public double Transparency => _barrier.Transparency;
    public bool IsClosed => _barrier.IsClosed;
    public bool IsRamResistant => _barrier.IsRamResistant;
    public double MinOvercomeTime => _barrier.MinOvercomeTime;
    public double MaxOvercomeTime => _barrier.MaxOvercomeTime;
    public bool IsSurmountableByResponseTeams => _barrier.IsSurmountableByResponseTeams;
}

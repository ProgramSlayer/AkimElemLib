using AkimElemLib.Wpf.Models.ISOs;
using System;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Fences;

public class FenceReadOnlyViewModel : ViewModelBase
{
    private readonly Fence _fence;

    public FenceReadOnlyViewModel(Fence fence)
    {
        ArgumentNullException.ThrowIfNull(fence, nameof(fence));
        _fence = fence;
    }

    public Guid Id => _fence.Id;
    public string Name => _fence.Name;
    public double Width => _fence.Width;
    public double Transparency => _fence.Transparency;
    public bool IsClosed => _fence.IsClosed;
    public bool IsRamResistant => _fence.IsRamResistant;
    public double MinOvercomeTime => _fence.MinOvercomeTime;
    public double MaxOvercomeTime => _fence.MaxOvercomeTime;
    public double Height => _fence.Height;
    public bool HasBase => _fence.HasBase;
    public bool HasAluminiumBarbedTape => _fence.HasAluminiumBarbedTape;
    public string MainSurfaceParams => _fence.MainSurfaceParams.ToString();
    public string TopParams => _fence.TopParams.ToString();
    public string BottomParams => _fence.BottomParams.ToString();
}

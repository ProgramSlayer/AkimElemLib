namespace AkimElemLib.Wpf.Models.ISOs;

public record FenceBottomParams(
    string Name,
    double Depth,
    double Width,
    bool SendsVibrations,
    bool SendsVibrationsToMainSurface);

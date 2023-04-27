namespace AkimElemLib.Wpf.Models.ISOs;

public record FenceTopParams(
    string Name,
    double Height,
    double Width,
    bool SendsVibrations,
    bool SendsVibrationsToMainSurface);

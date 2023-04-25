using AkimElemLib.Wpf.Models.Common;
using System;

namespace AkimElemLib.Wpf.Models.CctvCams;

public class StationaryCctvCam
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public required string Model { get; set; }
    public required double LightSensitivity { get; set; }
    public required PowerSupplyTypes PowerSupplyType { get; set; }
    public required double PowerConsumptionWatts { get; set; }
    public required double WorkingVoltage { get; set; }
    public required double MatrixDiagonalHorizontal { get; set; }
    public required double MatrixDiagonalVertical { get; set; }
    public required int ImageResolutionHorizontal { get; set; }
    public required int ImageResolutionVertical { get; set; }
    public required CctvCamVariofocalLensParams VariofocalLensParams { get; set; }
    public required double MinTemperature { get; set; }
    public required double MaxTemperature { get; set; }
    public required CctvCamMatrixFormats MatrixFormat { get; set; }
    public required double Omega { get; set; }
    public required double Phi { get; set; }
    public required double Alpha { get; set; }
    public required double AlphaMin { get; set; }
    public required double AlphaMax { get; set; }
    public required double Beta { get; set; }
    public required double InstallationHeight { get; set; }
    public required bool HasVideoAnalytics { get; set; }
    public required double Fps { get; set; }
    public required Probability DetectionProbability { get; set; }
    public required double MinReactionTime { get; set; }
}

public record CctvCamVariofocalLensParams(
    bool IsUsed,
    double MinFocalLength,
    double MaxFocalLength);
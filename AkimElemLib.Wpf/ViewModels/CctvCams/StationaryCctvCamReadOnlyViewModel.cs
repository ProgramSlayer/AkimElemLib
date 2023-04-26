using AkimElemLib.Wpf.Models.CctvCams;
using AkimElemLib.Wpf.Models.Common;
using System;

namespace AkimElemLib.Wpf.ViewModels.CctvCams;

public class StationaryCctvCamReadOnlyViewModel : ViewModelBase
{
    private readonly StationaryCctvCam _cam;

    public StationaryCctvCamReadOnlyViewModel(StationaryCctvCam cam)
    {
        ArgumentNullException.ThrowIfNull(cam, nameof(cam));
        _cam = cam;
    }

    public Guid Id => _cam.Id;
    public string Model => _cam.Model;
    public double LightSensitivity => _cam.LightSensitivity;
    public PowerSupplyTypes PowerSupplyType => _cam.PowerSupplyType;
    public double PowerConsumptionWatts => _cam.PowerConsumptionWatts;
    public double WorkingVoltage => _cam.WorkingVoltage;
    public double MatrixDiagonalHorizontal => _cam.MatrixDiagonalHorizontal;
    public double MatrixDiagonalVertical => _cam.MatrixDiagonalVertical;
    public double ImageResolutionHorizontal => _cam.ImageResolutionHorizontal;
    public double ImageResolutionVertical => _cam.ImageResolutionVertical;
    public string VariofocalLensParams => _cam.VariofocalLensParams.ToString();
    public double MinTemperature => _cam.MinTemperature;
    public double MaxTemperature => _cam.MaxTemperature;
    public CctvCamMatrixFormats MatrixFormat => _cam.MatrixFormat;
    public double Omega => _cam.Omega;
    public double Phi => _cam.Phi;
    public double Alpha => _cam.Alpha;
    public double AlphaMin => _cam.AlphaMin;
    public double AlphaMax => _cam.AlphaMax;
    public double Beta => _cam.Beta;
    public double InstallationHeight => _cam.InstallationHeight;
    public bool HasVideoAnalytics => _cam.HasVideoAnalytics;
    public double Fps => _cam.Fps;
    public Probability DetectionProbability => _cam.DetectionProbability;
    public double MinReactionTime => _cam.MinReactionTime;
}
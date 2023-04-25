using AkimElemLib.Wpf.Models.CctvCams;
using AkimElemLib.Wpf.Models.Common;
using System;

namespace AkimElemLib.Wpf.ViewModels.CctvCams;

public class EditStationaryCctvCamViewModel : ViewModelBase
{
    private string _model = string.Empty;
    private double _lightSensitivity;
    private PowerSupplyTypes _powerSupplyType;
    private double _powerConsumptionWatts;
    private double _workingVoltage;
    private double _matrixDiagonalHorizontal;
    private double _matrixDiagonalVertical;
    private int _imageResolutionHorizontal;
    private int _imageResolutionVertical;
    
    private double _minTemperature;
    private double _maxTemperature;

    private CctvCamMatrixFormats _matrixFormat;

    private double _omega;
    private double _phi;
    private double _alpha;
    private double _alphaMin;
    private double _alphaMax;
    private double _beta;
    private double _installationHeight;

    private bool _hasVideoAnalytics;
    private double _fps;
    private double _detectionProbability;
    private double _minReactionTime;

    public EditStationaryCctvCamViewModel(StationaryCctvCam? cam = null)
    {
        if (cam is not null)
        {
            Model = cam.Model;
            LightSensitivity = cam.LightSensitivity;
            PowerSupplyType = cam.PowerSupplyType;
            PowerConsumptionWatts = cam.PowerConsumptionWatts;
            WorkingVoltage = cam.WorkingVoltage;
            MatrixDiagonalHorizontal = cam.MatrixDiagonalHorizontal;
            MatrixDiagonalVertical = cam.MatrixDiagonalVertical;
            ImageResolutionHorizontal = cam.ImageResolutionHorizontal;
            ImageResolutionVertical = cam.ImageResolutionVertical;
            VariofocalLensParams = new(cam.VariofocalLensParams);
            MinTemperature = cam.MinTemperature;
            MaxTemperature = cam.MaxTemperature;
            MatrixFormat = cam.MatrixFormat;
            Omega = cam.Omega;
            Phi = cam.Phi;
            Alpha = cam.Alpha;
            AlphaMin = cam.AlphaMin;
            AlphaMax = cam.AlphaMax;
            Beta = cam.Beta;
            InstallationHeight = cam.InstallationHeight;
            HasVideoAnalytics = cam.HasVideoAnalytics;
            Fps = cam.Fps;
            DetectionProbability = cam.DetectionProbability;
            MinReactionTime = cam.MinReactionTime;
        }
    }

    public static PowerSupplyTypes[] PowerSupplyTypes => Enum.GetValues<PowerSupplyTypes>();
    public static CctvCamMatrixFormats[] MatrixFormats => Enum.GetValues<CctvCamMatrixFormats>();
    public string Model
    {
        get => _model; 
        set
        {
            _model = value;
            OnPropertyChanged();
        }
    }
    public double LightSensitivity
    {
        get => _lightSensitivity; 
        set
        {
            _lightSensitivity = value;
            OnPropertyChanged();
        }
    }
    public PowerSupplyTypes PowerSupplyType
    {
        get => _powerSupplyType; 
        set
        {
            _powerSupplyType = value;
            OnPropertyChanged();
        }
    }
    public double PowerConsumptionWatts 
    { 
        get => _powerConsumptionWatts; 
        set 
        {
            _powerConsumptionWatts = value;
            OnPropertyChanged();
        } 
    }
    public double WorkingVoltage
    {
        get => _workingVoltage; 
        set
        {
            _workingVoltage = value;
            OnPropertyChanged();
        }
    }
    public double MatrixDiagonalHorizontal
    {
        get => _matrixDiagonalHorizontal; 
        set
        {
            _matrixDiagonalHorizontal = value;
            OnPropertyChanged();
        }
    }
    public double MatrixDiagonalVertical
    {
        get => _matrixDiagonalVertical; 
        set
        {
            _matrixDiagonalVertical = value;
            OnPropertyChanged();
        }
    }
    public int ImageResolutionHorizontal
    {
        get => _imageResolutionHorizontal; 
        set
        {
            _imageResolutionHorizontal = value;
            OnPropertyChanged();
        }
    }
    public int ImageResolutionVertical
    {
        get => _imageResolutionVertical; 
        set
        {
            _imageResolutionVertical = value;
            OnPropertyChanged();
        }
    }
    public EditCctvCamVariofocalLensParamsViewModel VariofocalLensParams { get; set; } = new();
    public double MinTemperature
    {
        get => _minTemperature; 
        set
        {
            _minTemperature = value;
            OnPropertyChanged();
        }
    }
    public double MaxTemperature
    {
        get => _maxTemperature; 
        set
        {
            _maxTemperature = value;
            OnPropertyChanged();
        }
    }
    public CctvCamMatrixFormats MatrixFormat
    {
        get => _matrixFormat; 
        set
        {
            _matrixFormat = value;
            OnPropertyChanged();
        }
    }
    public double Omega
    {
        get => _omega; 
        set
        {
            _omega = value;
            OnPropertyChanged();
        }
    }
    public double Phi
    {
        get => _phi; 
        set
        {
            _phi = value;
            OnPropertyChanged();
        }
    }
    public double Alpha
    {
        get => _alpha; 
        set
        {
            _alpha = value;
            OnPropertyChanged();
        }
    }
    public double AlphaMin
    {
        get => _alphaMin; 
        set
        {
            _alphaMin = value;
            OnPropertyChanged();
        }
    }
    public double AlphaMax
    {
        get => _alphaMax; 
        set
        {
            _alphaMax = value;
            OnPropertyChanged();
        }
    }
    public double Beta
    {
        get => _beta; 
        set
        {
            _beta = value;
            OnPropertyChanged();
        }
    }
    public double InstallationHeight
    {
        get => _installationHeight; 
        set
        {
            _installationHeight = value;
            OnPropertyChanged();
        }
    }
    public bool HasVideoAnalytics
    {
        get => _hasVideoAnalytics; 
        set
        {
            _hasVideoAnalytics = value;
            OnPropertyChanged();
        }
    }
    public double Fps
    {
        get => _fps; 
        set
        {
            _fps = value;
            OnPropertyChanged();
        }
    }
    public double DetectionProbability
    {
        get => _detectionProbability; 
        set
        {
            _detectionProbability = value;
            OnPropertyChanged();
        }
    }
    public double MinReactionTime
    {
        get => _minReactionTime; 
        set
        {
            _minReactionTime = value;
            OnPropertyChanged();
        }
    }
}

using AkimElemLib.Wpf.Models.Common;
using AkimElemLib.Wpf.Models.ISOs;
using System;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Obstacles;

public class EditObstacleViewModel : ViewModelBase
{
    private string _name = string.Empty;
    private double _length;
    private double _width;
    private double _height;
    private double _heightRelativeToGround;
    private double _transparency;
    private VelocityMeasureUnits _velocityMeasureUnit;
    private double _maxVelocity;
    private bool _hasBase;
    private bool _hasAluminiumBarbedTape;
    private bool _isRamResistant;
    private double _minOvercomeTime;
    private double _maxOvercomeTime;
    private double _minEntranceDelay;
    private double _maxEntranceDelay;
    private double _minExitDelay;
    private double _maxExitDelay;
    private bool _isSurmountableByResponseTeams;

    public static VelocityMeasureUnits[] VelocityMeasureUnits => 
        Enum.GetValues<VelocityMeasureUnits>();

    public string Name
    {
        get => _name; 
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    public double Length
    {
        get => _length; 
        set
        {
            _length = value;
            OnPropertyChanged();
        }
    }
    public double Width
    {
        get => _width; 
        set
        {
            _width = value;
            OnPropertyChanged();
        }
    }
    public double Height
    {
        get => _height; 
        set
        {
            _height = value;
            OnPropertyChanged();
        }
    }
    public double HeightRelativeToGround
    {
        get => _heightRelativeToGround; 
        set
        {
            _heightRelativeToGround = value;
            OnPropertyChanged();
        }
    }
    public double Transparency
    {
        get => _transparency; 
        set
        {
            _transparency = value;
            OnPropertyChanged();
        }
    }
    public VelocityMeasureUnits VelocityMeasureUnit
    {
        get => _velocityMeasureUnit; 
        set
        {
            _velocityMeasureUnit = value;
            OnPropertyChanged();
        }
    }
    public double MaxVelocity
    {
        get => _maxVelocity; 
        set
        {
            _maxVelocity = value;
            OnPropertyChanged();
        }
    }
    public bool HasBase
    {
        get => _hasBase; 
        set
        {
            _hasBase = value;
            OnPropertyChanged();
        }
    }
    public bool HasAluminiumBarbedTape
    {
        get => _hasAluminiumBarbedTape; 
        set
        {
            _hasAluminiumBarbedTape = value;
            OnPropertyChanged();
        }
    }
    public EditObstacleVisorFenceParamsViewModel VisorFenceParams { get; set; } = new();
    public EditObstacleAntiUndercarriageDeviceParamsViewModel AntiUndercarriageDeviceParams { get; set; } = new();
    public bool IsRamResistant
    {
        get => _isRamResistant; 
        set
        {
            _isRamResistant = value;
            OnPropertyChanged();
        }
    }
    public double MinOvercomeTime
    {
        get => _minOvercomeTime; 
        set
        {
            _minOvercomeTime = value;
            OnPropertyChanged();
        }
    }
    public double MaxOvercomeTime
    {
        get => _maxOvercomeTime; 
        set
        {
            _maxOvercomeTime = value;
            OnPropertyChanged();
        }
    }
    public double MinEntranceDelay
    {
        get => _minEntranceDelay; 
        set
        {
            _minEntranceDelay = value;
            OnPropertyChanged();
        }
    }
    public double MaxEntranceDelay
    {
        get => _maxEntranceDelay; 
        set
        {
            _maxEntranceDelay = value;
            OnPropertyChanged();
        }
    }
    public double MinExitDelay
    {
        get => _minExitDelay; 
        set
        {
            _minExitDelay = value;
            OnPropertyChanged();
        }
    }
    public double MaxExitDelay
    {
        get => _maxExitDelay; 
        set
        {
            _maxExitDelay = value;
            OnPropertyChanged();
        }
    }
    public bool IsSurmountableByResponseTeams
    {
        get => _isSurmountableByResponseTeams; 
        set
        {
            _isSurmountableByResponseTeams = value;
            OnPropertyChanged();
        }
    }

    public EditObstacleViewModel(Obstacle? o = null)
    {
        if (o is not null)
        {
            Name = o.Name;
            Length = o.Length;
            Width = o.Width;
            Height = o.Height;
            HeightRelativeToGround = o.HeightRelativeToGround;
            Transparency = o.Transparency;
            VelocityMeasureUnit = o.VelocityMeasureUnit;
            MaxVelocity = o.MaxVelocity;
            HasBase = o.HasBase;
            HasAluminiumBarbedTape = o.HasAluminiumBarbedTape;
            VisorFenceParams = new(o.VisorFenceParams);
            AntiUndercarriageDeviceParams = new(o.AntiUndercarriageDeviceParams);
            IsRamResistant = o.IsRamResistant;
            MinOvercomeTime = o.MinOvercomeTime;
            MaxOvercomeTime = o.MaxOvercomeTime;
            MinEntranceDelay = o.MinEntranceDelay;
            MaxEntranceDelay = o.MaxEntranceDelay;
            MinExitDelay = o.MinExitDelay;
            MaxExitDelay = o.MaxExitDelay;
            IsSurmountableByResponseTeams = o.IsSurmountableByResponseTeams;
        }
    }
}

public class EditObstacleVisorFenceParamsViewModel : ViewModelBase
{
    private bool _isUsed;
    private double _height;

    public bool IsUsed
    {
        get => _isUsed; 
        set
        {
            _isUsed = value;
            OnPropertyChanged();
            if (!value)
            {
                Height = 0;
            }
        }
    }
    public double Height
    {
        get => _height; 
        set
        {
            _height = value;
            OnPropertyChanged();
        }
    }

    public EditObstacleVisorFenceParamsViewModel(
        ObstacleVisorFenceParams? @params = null)
    {
        if (@params is not null)
        {
            IsUsed = @params.IsUsed;
            Height = @params.Height;
        }
    }
}

public class EditObstacleAntiUndercarriageDeviceParamsViewModel : ViewModelBase
{
    private bool _isUsed;
    private double _depth;

    public bool IsUsed
    {
        get => _isUsed; 
        set
        {
            _isUsed = value;
            OnPropertyChanged();
            if (!value)
            {
                Depth = 0;
            }
        }
    }

    public double Depth
    {
        get => _depth; 
        set
        {
            _depth = value;
            OnPropertyChanged();
        }
    }

    public EditObstacleAntiUndercarriageDeviceParamsViewModel(
        ObstacleAntiUndercarriageDeviceParams? @params = null)
    {
        if (@params is not null)
        {
            IsUsed = @params.IsUsed;
            Depth = @params.Depth;
        }
    }
}
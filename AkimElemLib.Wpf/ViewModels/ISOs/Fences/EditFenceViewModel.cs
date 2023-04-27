using AkimElemLib.Wpf.Models.ISOs;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Fences;

public class EditFenceViewModel : ViewModelBase
{
    private string _name = string.Empty;
    private double _width;
    private double _transparency;
    private bool _isClosed;
    private bool _isRamResistant;
    private double _minOvercomeTime;
    private double _maxOvercomeTime;
    private double _height;
    private bool _hasBase;
    private bool _hasAluminiumBarbedTape;

    public string Name
    {
        get => _name; 
        set
        {
            _name = value;
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
    public double Transparency
    {
        get => _transparency; 
        set
        {
            _transparency = value;
            OnPropertyChanged();
        }
    }
    public bool IsClosed
    {
        get => _isClosed; 
        set
        {
            _isClosed = value;
            OnPropertyChanged();
        }
    }
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
    public double Height
    {
        get => _height; 
        set
        {
            _height = value;
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

    public EditFenceMainSurfaceParamsViewModel MainSurfaceParams { get; set; } = new();
    public EditFenceTopParamsViewModel TopParams { get; set; } = new();
    public EditFenceBottomParamsViewModel BottomParams { get; set; } = new();

    public EditFenceViewModel(Fence? fence = null)
    {
        if (fence is not null)
        {
            Name = fence.Name;
            Width = fence.Width;
            Transparency = fence.Transparency;
            IsClosed = fence.IsClosed;
            IsRamResistant = fence.IsRamResistant;
            MinOvercomeTime = fence.MinOvercomeTime;
            MaxOvercomeTime = fence.MaxOvercomeTime;
            Height = fence.Height;
            HasBase = fence.HasBase;
            HasAluminiumBarbedTape = fence.HasAluminiumBarbedTape;
            MainSurfaceParams = new(fence.MainSurfaceParams);
            TopParams = new(fence.TopParams);
            BottomParams = new(fence.BottomParams);
        }
    }
}

public class EditFenceMainSurfaceParamsViewModel : ViewModelBase
{
    private string _name = string.Empty;
    private double _height;
    private double _width;
    private bool _sendsVibrations;

    public string Name
    {
        get => _name;
        set 
        { 
            _name = value;
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
    public double Width
    {
        get => _width;
        set 
        { 
            _width = value;
            OnPropertyChanged();
        }
    }
    public bool SendsVibrations
    {
        get => _sendsVibrations;
        set 
        { 
            _sendsVibrations = value;
            OnPropertyChanged();
        }
    }

    public EditFenceMainSurfaceParamsViewModel(FenceMainSurfaceParams? @params = null)
    {
        if (@params is not null)
        {
            Name = @params.Name;
            Height = @params.Height;
            Width = @params.Width;
            SendsVibrations = @params.SendsVibrations;
        }
    }
}

public class EditFenceTopParamsViewModel : ViewModelBase
{
    private string _name = string.Empty;
    private double _height;
    private double _width;
    private bool _sendsVibrations;
    private bool _sendsVibrationsToMainSurface;

    public string Name
    {
        get => _name; 
        set
        {
            _name = value;
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
    public double Width
    {
        get => _width; 
        set
        {
            _width = value;
            OnPropertyChanged();
        }
    }
    public bool SendsVibrations
    {
        get => _sendsVibrations; 
        set
        {
            _sendsVibrations = value;
            OnPropertyChanged();
        }
    }
    public bool SendsVibrationsToMainSurface
    {
        get => _sendsVibrationsToMainSurface; 
        set
        {
            _sendsVibrationsToMainSurface = value;
            OnPropertyChanged();
        }
    }

    public EditFenceTopParamsViewModel(FenceTopParams? @params = null)
    {
        if (@params is not null)
        {
            Name = @params.Name;
            Height = @params.Height;
            Width = @params.Width;
            SendsVibrations = @params.SendsVibrations;
            SendsVibrationsToMainSurface = @params.SendsVibrationsToMainSurface;
        }
    }
}

public class EditFenceBottomParamsViewModel : ViewModelBase
{
    private string _name = string.Empty;
    private double _depth;
    private double _width;
    private bool _sendsVibrations;
    private bool _sendsVibrationsToMainSurface;

    public string Name
    {
        get => _name; 
        set
        {
            _name = value;
            OnPropertyChanged();
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
    public double Width
    {
        get => _width; 
        set
        {
            _width = value;
            OnPropertyChanged();
        }
    }
    public bool SendsVibrations
    {
        get => _sendsVibrations; 
        set
        {
            _sendsVibrations = value;
            OnPropertyChanged();
        }
    }
    public bool SendsVibrationsToMainSurface
    {
        get => _sendsVibrationsToMainSurface; 
        set
        {
            _sendsVibrationsToMainSurface = value;
            OnPropertyChanged();
        }
    }

    public EditFenceBottomParamsViewModel(FenceBottomParams? @params = null)
    {
        if (@params is not null)
        {
            Name = @params.Name;
            Depth = @params.Depth;
            Width = @params.Width;
            SendsVibrations = @params.SendsVibrations;
            SendsVibrationsToMainSurface = @params.SendsVibrationsToMainSurface;
        }
    }
}

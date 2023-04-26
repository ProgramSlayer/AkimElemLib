using AkimElemLib.Wpf.Models.ISOs;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Barriers;

public class EditBarrierViewModel : ViewModelBase
{
    private string _name = string.Empty;
    private double _height;
    private double _heightRelativeToGround;
    private double _width;
    private double _transparency;
    private bool _isClosed;
    private bool _isRamResistant;
    private double _minOvercomeTime;
    private double _maxOvercomeTime;
    private bool _isSurmountableByResponseTeams;

    public EditBarrierViewModel(Barrier? barrier = null)
    {
        if (barrier is not null)
        {
            Name = barrier.Name;
            Height = barrier.Height;
            HeightRelativeToGround = barrier.HeightRelativeToGround;
            Width = barrier.Width;
            Transparency = barrier.Transparency;
            IsClosed = barrier.IsClosed;
            IsRamResistant = barrier.IsRamResistant;
            MinOvercomeTime = barrier.MinOvercomeTime;
            MaxOvercomeTime = barrier.MaxOvercomeTime;
            IsSurmountableByResponseTeams = barrier.IsSurmountableByResponseTeams;
        }
    }

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
    public double HeightRelativeToGround
    {
        get => _heightRelativeToGround; 
        set
        {
            _heightRelativeToGround = value;
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
    public bool IsSurmountableByResponseTeams
    {
        get => _isSurmountableByResponseTeams; 
        set
        {
            _isSurmountableByResponseTeams = value;
            OnPropertyChanged();
        }
    }
}

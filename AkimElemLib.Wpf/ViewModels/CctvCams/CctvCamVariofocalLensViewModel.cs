namespace AkimElemLib.Wpf.ViewModels.CctvCams;

public class EditCctvCamVariofocalLensViewModel : ViewModelBase
{
    private bool _variofocalLensIsUsed;
    private double _minFocalLength;
    private double _maxFocalLength;

    public bool VariofocalLensIsUsed
    {
        get => _variofocalLensIsUsed; 
        set
        {
            _variofocalLensIsUsed = value;
            OnPropertyChanged();
            if (!value)
            {
                MinFocalLength = 0;
                MaxFocalLength = 0;
            }
        }
    }
    public double MinFocalLength
    {
        get => _minFocalLength; 
        set
        {
            _minFocalLength = value;
            OnPropertyChanged();
        }
    }
    public double MaxFocalLength
    {
        get => _maxFocalLength; 
        set
        {
            _maxFocalLength = value;
            OnPropertyChanged();
        }
    }
}
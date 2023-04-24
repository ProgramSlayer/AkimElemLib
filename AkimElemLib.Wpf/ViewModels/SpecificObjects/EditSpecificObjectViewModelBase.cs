using AkimElemLib.Wpf.Models.Common;
using AkimElemLib.Wpf.Models.SpecificObjects;
using System;

namespace AkimElemLib.Wpf.ViewModels.SpecificObjects;

public abstract class EditSpecificObjectViewModelBase : ViewModelBase
{
    private string _name = string.Empty;
    private VelocityMeasureUnits _velocityMeasureUnit;
    private double _maxVelocity;
    private double _transparency;
    private double _height;
    private double _heightRelativeToGround;

    public static VelocityMeasureUnits[] VelocityMeasureUnits => Enum.GetValues<VelocityMeasureUnits>();

    public string Name
    {
        get => _name; 
        set
        {
            _name = value;
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
    public double Transparency
    {
        get => _transparency; 
        set
        {
            _transparency = value;
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

    protected EditSpecificObjectViewModelBase(SpecificObjectBase? specificObject = null)
    {
        if (specificObject is not null)
        {
            Name = specificObject.Name;
            VelocityMeasureUnit = specificObject.VelocityMeasureUnit;
            MaxVelocity = specificObject.MaxVelocity;
            Transparency = specificObject.Transparency;
            Height = specificObject.Height;
            HeightRelativeToGround = specificObject.HeightRelativeToGround;
        }
    }
}

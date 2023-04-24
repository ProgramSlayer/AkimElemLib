using AkimElemLib.Wpf.Models.Common;
using AkimElemLib.Wpf.Models.SpecificObjects;
using System;

namespace AkimElemLib.Wpf.ViewModels.SpecificObjects;

public abstract class SpecificObjectReadOnlyViewModelBase : ViewModelBase
{
    private readonly SpecificObjectBase _specificObject;

    protected SpecificObjectReadOnlyViewModelBase(SpecificObjectBase specificObject) => 
        _specificObject = specificObject ?? throw new System.ArgumentNullException(nameof(specificObject));

    public Guid Id => _specificObject.Id;
    public string Name => _specificObject.Name;
    public VelocityMeasureUnits VelocityMeasureUnit => _specificObject.VelocityMeasureUnit;
    public double MaxVelocity => _specificObject.MaxVelocity;
    public double Transparency => _specificObject.Transparency;
    public double Height => _specificObject.Height;
    public double HeightRelativeToGround => _specificObject.HeightRelativeToGround;
}

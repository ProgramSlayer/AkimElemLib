using AkimElemLib.Wpf.Models.Common;
using System;

namespace AkimElemLib.Wpf.Models.SpecificObjects;

public abstract class SpecificObjectBase
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required VelocityMeasureUnits VelocityMeasureUnit { get; set; }
    public required double MaxVelocity { get; set; }
    public required double Transparency { get; set; }
    public required double Height { get; set; }
    public required double HeightRelativeToGround { get; set; }
}

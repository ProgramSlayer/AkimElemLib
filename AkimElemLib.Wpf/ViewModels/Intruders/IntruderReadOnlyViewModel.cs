using AkimElemLib.Wpf.Models.Intruders;
using System;

namespace AkimElemLib.Wpf.ViewModels.Intruders;

public class IntruderReadOnlyViewModel : ViewModelBase
{
    private readonly Intruder _intruder;

    public IntruderReadOnlyViewModel(Intruder intruder) => 
        _intruder = intruder ?? throw new System.ArgumentNullException(nameof(intruder));

    public Guid Id => _intruder.Id;
    public string Name => _intruder.Name;
    public string VelocityParams => 
        $"Velocity Measure Unit: {_intruder.VelocityParams.VelocityMeasureUnit}\n" +
        $"Min Velocity: {_intruder.VelocityParams.MinVelocity}\n" +
        $"Max Velocity: {_intruder.VelocityParams.MaxVelocity}";
    public string AccomplicesParams => _intruder.AccomplicesParams.ToString();
    public string CarParams => _intruder.CarParams.ToString();
    public string PsychophysicalParams => _intruder.PsychophysicalParams.ToString();
    public string LightEquipment => _intruder.LightEquipment.ToString();
    public string MediumEquipment => _intruder.MediumEquipment.ToString();
    public string HeavyEquipment => _intruder.HeavyEquipment.ToString();
    public double DropEquipmentProbability => _intruder.DropEquipmentProbability.Value;
    public string LengthParams => _intruder.LengthParams.ToString();
    public string HeightParams => _intruder.HeightParams.ToString();
    public string WidthParams => _intruder.WidthParams.ToString();
}

using AkimElemLib.Wpf.Models.Intruders;
using AkimElemLib.Wpf.Models.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.Models.SpecificObjects.Buildings;
using AkimElemLib.Wpf.Models.SpecificObjects.SpecificAreas;
using AkimElemLib.Wpf.ViewModels.Intruders;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.Buildings;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.SpecificAreas;

namespace AkimElemLib.Wpf.Extensions;

public static class ViewModelExtensions
{
    public static AerialConstruction ToAerialConstruction(this EditAerialConstructionViewModel vm) => new()
    {
        Name = vm.Name,
        Height = vm.Height,
        HeightRelativeToGround = vm.HeightRelativeToGround,
        MaxVelocity = vm.MaxVelocity,
        Transparency = vm.Transparency,
        VelocityMeasureUnit = vm.VelocityMeasureUnit,
    };

    public static void ToAerialConstruction(this EditAerialConstructionViewModel source, AerialConstruction target)
    {
        target.Name = source.Name;
        target.Height = source.Height;
        target.HeightRelativeToGround = source.HeightRelativeToGround;
        target.MaxVelocity = source.MaxVelocity;
        target.Transparency = source.Transparency;
        target.VelocityMeasureUnit = source.VelocityMeasureUnit;
    }

    public static Building ToBuilding(this EditBuildingViewModel vm) => new()
    {
        Name = vm.Name,
        Height = vm.Height,
        HeightRelativeToGround = vm.HeightRelativeToGround,
        MaxVelocity = vm.MaxVelocity,
        Transparency = vm.Transparency,
        VelocityMeasureUnit = vm.VelocityMeasureUnit,
    };

    public static void ToBuilding(this EditBuildingViewModel source, Building target)
    {
        target.Name = source.Name;
        target.Height = source.Height;
        target.HeightRelativeToGround = source.HeightRelativeToGround;
        target.MaxVelocity = source.MaxVelocity;
        target.Transparency = source.Transparency;
        target.VelocityMeasureUnit = source.VelocityMeasureUnit;
    }

    public static SpecificArea ToSpecificArea(this EditSpecificAreaViewModel vm) => new()
    {
        Name = vm.Name,
        Height = vm.Height,
        HeightRelativeToGround = vm.HeightRelativeToGround,
        MaxVelocity = vm.MaxVelocity,
        Transparency = vm.Transparency,
        VelocityMeasureUnit = vm.VelocityMeasureUnit,
    };

    public static void ToSpecificArea(this EditSpecificAreaViewModel source, SpecificArea target)
    {
        target.Name = source.Name;
        target.Height = source.Height;
        target.HeightRelativeToGround = source.HeightRelativeToGround;
        target.MaxVelocity = source.MaxVelocity;
        target.Transparency = source.Transparency;
        target.VelocityMeasureUnit = source.VelocityMeasureUnit;
    }

    public static Intruder ToIntruder(this EditIntruderViewModel vm) => new()
    {
        VelocityParams = vm.VelocityParams.ToIntruderVelocityParams(),
        AccomplicesParams = vm.AccomplicesParams.ToIntruderAccomplicesParams(),
        CarParams = vm.CarParams.ToIntruderCarParams(),
        PsychophysicalParams = vm.PsychophysicalParams.ToIntruderPsychophysicalParams(),
        LightEquipment = vm.LightEquipment.ToIntruderEquipmentParams(),
        MediumEquipment = vm.MediumEquipment.ToIntruderEquipmentParams(),
        HeavyEquipment = vm.HeavyEquipment.ToIntruderEquipmentParams(),
        DropEquipmentProbability = new(vm.DropEquipmentProbability),
        HeightParams = vm.ComplexionParams.HeightMm.ToIntruderDimensionsParams(),
        LengthParams = vm.ComplexionParams.LengthMm.ToIntruderDimensionsParams(),
        WidthParams = vm.ComplexionParams.WidthMm.ToIntruderDimensionsParams(),
    };

    public static void ToIntruder(this EditIntruderViewModel source, Intruder target)
    {
        target.VelocityParams = source.VelocityParams.ToIntruderVelocityParams();
        target.AccomplicesParams = source.AccomplicesParams.ToIntruderAccomplicesParams();
        target.CarParams = source.CarParams.ToIntruderCarParams();
        target.PsychophysicalParams = source.PsychophysicalParams.ToIntruderPsychophysicalParams();
        target.LightEquipment = source.LightEquipment.ToIntruderEquipmentParams();
        target.MediumEquipment = source.MediumEquipment.ToIntruderEquipmentParams();
        target.HeavyEquipment = source.HeavyEquipment.ToIntruderEquipmentParams();
        target.DropEquipmentProbability = source.DropEquipmentProbability;
        target.LengthParams = source.ComplexionParams.LengthMm.ToIntruderDimensionsParams();
        target.HeightParams = source.ComplexionParams.HeightMm.ToIntruderDimensionsParams();
        target.WidthParams = source.ComplexionParams.WidthMm.ToIntruderDimensionsParams();
    }

    public static IntruderVelocityParams ToIntruderVelocityParams(this EditIntruderVelocityParamsViewModel vm)
    {
        return new IntruderVelocityParams(
            vm.VelocityMeasureUnit,
            vm.MinVelocity,
            vm.MaxVelocity);
    }

    public static IntruderPsychophysicalParams ToIntruderPsychophysicalParams(this EditIntruderPsychophysicalParamsViewModel vm)
    {
        return new IntruderPsychophysicalParams(
            vm.UnnoticedIntrusionProbability,
            vm.CautionDropTo0Probability,
            vm.IntrusionRefusalProbability,
            vm.VelocityChangeProbability,
            vm.VelocityIncreaseProbability,
            vm.MovementDirectionChangeProbability,
            vm.MinRunawayDistance,
            vm.MaxRunawayDistance,
            vm.ObjectTerritoryKnowledgePercent,
            vm.AerialConstructionIntrusionProbability);
    }

    public static IntruderDimensionsParams ToIntruderDimensionsParams(this EditIntruderDimensionParamsViewModel vm)
    {
        return new IntruderDimensionsParams(
            vm.FullHeightMm,
            vm.DeepSquatMm,
            vm.CrawlingMm);
    }

    public static IntruderEquipmentParams ToIntruderEquipmentParams(this EditIntruderEquipmentParamsViewModel vm)
    {
        return new IntruderEquipmentParams(
            vm.IsUsed,
            vm.ObstacleOvercomeTimeDecreaseCoefficient,
            vm.VelocityDecreaseCoefficient);
    }

    public static IntruderCarParams ToIntruderCarParams(this EditIntruderCarParamsViewModel vm)
    {
        return new IntruderCarParams(
            vm.HasCar,
            vm.VelocityIncreaseCoefficient,
            vm.CarDropProbability);
    }

    public static IntruderAccomplicesParams ToIntruderAccomplicesParams(this EditIntruderAccomplicesParamsViewModel vm)
    {
        return new IntruderAccomplicesParams(
            vm.HasAccomplices,
            vm.Iso2xDelayDropProbability,
            vm.Sensors2xDetectionDecreaseProbability,
            vm.TimeTillIntentionalFalseAlarm);
    }
}

﻿using AkimElemLib.Wpf.Models.CctvCams;
using AkimElemLib.Wpf.Models.Intruders;
using AkimElemLib.Wpf.Models.ISOs;
using AkimElemLib.Wpf.Models.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.Models.SpecificObjects.Buildings;
using AkimElemLib.Wpf.Models.SpecificObjects.SpecificAreas;
using AkimElemLib.Wpf.ViewModels.CctvCams;
using AkimElemLib.Wpf.ViewModels.Intruders;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.Buildings;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.SpecificAreas;
using AkimElemLib.Wpf.ViewModels.ISOs.Barriers;

namespace AkimElemLib.Wpf.Extensions;

public static class ViewModelExtensions
{
    public static Barrier ToBarrier(this EditBarrierViewModel vm) => new()
    {
        Name = vm.Name,
        Height = vm.Height,
        HeightRelativeToGround = vm.HeightRelativeToGround,
        Width = vm.Width,
        Transparency = vm.Transparency,
        IsClosed = vm.IsClosed,
        IsRamResistant = vm.IsRamResistant,
        MinOvercomeTime = vm.MinOvercomeTime,
        MaxOvercomeTime = vm.MaxOvercomeTime,
        IsSurmountableByResponseTeams = vm.IsSurmountableByResponseTeams,
    };

    public static void ToBarrier(this EditBarrierViewModel source, Barrier target)
    {
        target.Name = source.Name;
        target.Height = source.Height;
        target.HeightRelativeToGround = source.HeightRelativeToGround;
        target.Width = source.Width;
        target.Transparency = source.Transparency;
        target.IsClosed = source.IsClosed;
        target.IsRamResistant = source.IsRamResistant;
        target.MinOvercomeTime = source.MinOvercomeTime;
        target.MaxOvercomeTime = source.MaxOvercomeTime;
        target.IsSurmountableByResponseTeams = source.IsSurmountableByResponseTeams;
    }

    public static StationaryCctvCam ToStationaryCctvCam(this EditStationaryCctvCamViewModel vm) => new StationaryCctvCam()
    {
        Model = vm.Model,
        LightSensitivity = vm.LightSensitivity,
        PowerSupplyType = vm.PowerSupplyType,
        PowerConsumptionWatts = vm.PowerConsumptionWatts,
        WorkingVoltage = vm.WorkingVoltage,
        MatrixDiagonalHorizontal = vm.MatrixDiagonalHorizontal,
        MatrixDiagonalVertical = vm.MatrixDiagonalVertical,
        ImageResolutionHorizontal = vm.ImageResolutionHorizontal,
        ImageResolutionVertical = vm.ImageResolutionVertical,
        VariofocalLensParams = vm.VariofocalLensParams.ToCctvCamVariofocalLensParams(),
        MinTemperature = vm.MinTemperature,
        MaxTemperature = vm.MaxTemperature,
        MatrixFormat = vm.MatrixFormat,
        Omega = vm.Omega,
        Phi = vm.Phi,
        Alpha = vm.Alpha,
        AlphaMin = vm.AlphaMin,
        AlphaMax = vm.AlphaMax,
        Beta = vm.Beta,
        InstallationHeight = vm.InstallationHeight,
        HasVideoAnalytics = vm.HasVideoAnalytics,
        Fps = vm.Fps,
        DetectionProbability = vm.DetectionProbability,
        MinReactionTime = vm.MinReactionTime,
    };

    public static void ToStationaryCctvCam(this EditStationaryCctvCamViewModel source, StationaryCctvCam target)
    {
        target.Model = source.Model;
        target.LightSensitivity = source.LightSensitivity;
        target.PowerSupplyType = source.PowerSupplyType;
        target.PowerConsumptionWatts = source.PowerConsumptionWatts;
        target.WorkingVoltage = source.WorkingVoltage;
        target.MatrixDiagonalHorizontal = source.MatrixDiagonalHorizontal;
        target.MatrixDiagonalVertical = source.MatrixDiagonalVertical;
        target.ImageResolutionHorizontal = source.ImageResolutionHorizontal;
        target.ImageResolutionVertical = source.ImageResolutionVertical;
        target.VariofocalLensParams = source.VariofocalLensParams.ToCctvCamVariofocalLensParams();
        target.MinTemperature = source.MinTemperature;
        target.MaxTemperature = source.MaxTemperature;
        target.MatrixFormat = source.MatrixFormat;
        target.Omega = source.Omega;
        target.Phi = source.Phi;
        target.Alpha = source.Alpha;
        target.AlphaMin = source.AlphaMin;
        target.AlphaMax = source.AlphaMax;
        target.Beta = source.Beta;
        target.InstallationHeight = source.InstallationHeight;
        target.HasVideoAnalytics = source.HasVideoAnalytics;
        target.Fps = source.Fps;
        target.DetectionProbability = source.DetectionProbability;
        target.MinReactionTime = source.MinReactionTime;
    }

    public static CctvCamVariofocalLensParams ToCctvCamVariofocalLensParams(this EditCctvCamVariofocalLensParamsViewModel vm)
    {
        return new CctvCamVariofocalLensParams(vm.VariofocalLensIsUsed, vm.MinFocalLength, vm.MaxFocalLength);
    }

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
        Name = vm.Name,
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

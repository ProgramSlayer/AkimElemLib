using AkimElemLib.Wpf.Models.Common;
using System;

namespace AkimElemLib.Wpf.Models.Intruders;

public class Intruder
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public required IntruderVelocityParams VelocityParams { get; set; }
    public required IntruderAccomplicesParams AccomplicesParams { get; set; }
    public required IntruderCarParams CarParams { get; set; }
    public required IntruderPsychophysicalParams PsychophysicalParams { get; set; }
    public required IntruderEquipmentParams LightEquipment { get; set; }
    public required IntruderEquipmentParams MediumEquipment { get; set; }
    public required IntruderEquipmentParams HeavyEquipment { get; set; }
    public required Probability DropEquipmentProbability { get; set; }
    public required IntruderDimensionsParams LengthParams { get; set; }
    public required IntruderDimensionsParams HeightParams { get; set; }
    public required IntruderDimensionsParams WidthParams { get; set; }
}

public record IntruderDimensionsParams(
    int FullHeightMm,
    int DeepSquatMm,
    int CrawlingMm);

public record IntruderEquipmentParams(
    bool IsUsed,
    double ObstacleOvercomeTimeDecreaseCoefficient,
    double VelocityDecreaseCoefficient);

public record IntruderPsychophysicalParams(
    Probability UnnoticedIntrusionProbability,
    Probability CautionDropTo0Probability,
    Probability IntrusionRefusalProbability,
    Probability VelocityChangeProbability,
    Probability VelocityIncreaseProbability,
    Probability MovementDirectionChangeProbability,
    double MinRunawayDistance,
    double MaxRunawayDistance,
    int ObjectTerritoryKnowledgePercent,
    Probability AerialConstructionIntrusionProbability);

public record IntruderCarParams(
    bool HasCar,
    double VelocityIncreaseCoefficient,
    Probability CarDropProbability);

public record IntruderAccomplicesParams(
    bool HasAccomplices,
    Probability Iso2xDelayDropProbability,
    Probability Sensors2xDetectionDecreaseProbability,
    double TimeTillIntentionalFalseAlarm);

public record IntruderVelocityParams(
    VelocityMeasureUnits VelocityMeasureUnit,
    double MinVelocity,
    double MaxVelocity);
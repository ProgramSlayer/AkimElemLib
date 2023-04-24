using AkimElemLib.Wpf.Models.Common;
using AkimElemLib.Wpf.Models.Intruders;
using System;

namespace AkimElemLib.Wpf.ViewModels.Intruders;

public class EditIntruderViewModel : ViewModelBase
{
    private double _dropEquipmentProbability;

    public EditIntruderVelocityParamsViewModel VelocityParams { get; set; } = new();
    public EditIntruderAccomplicesParamsViewModel AccomplicesParams { get; set; } = new();
    public EditIntruderCarParamsViewModel CarParams { get; set; } = new();
    public EditIntruderPsychophysicalParamsViewModel PsychophysicalParams { get; set; } = new();
    public EditIntruderEquipmentParamsViewModel LightEquipment { get; set; } = new();
    public EditIntruderEquipmentParamsViewModel MediumEquipment { get; set; } = new();
    public EditIntruderEquipmentParamsViewModel HeavyEquipment { get; set; } = new();
    public double DropEquipmentProbability
    {
        get => _dropEquipmentProbability; 
        set
        {
            _dropEquipmentProbability = value;
            OnPropertyChanged();
        }
    }
    public EditIntruderComplexionParamsViewModel ComplexionParams { get; set; } = new();

    public EditIntruderViewModel()
    {
    }

    public EditIntruderViewModel(Intruder intruder)
    {
        ArgumentNullException.ThrowIfNull(intruder, nameof(intruder));
        VelocityParams = new(intruder.VelocityParams);
        AccomplicesParams = new(intruder.AccomplicesParams);
        CarParams = new(intruder.CarParams);
        PsychophysicalParams = new(intruder.PsychophysicalParams);
        LightEquipment = new(intruder.LightEquipment);
        MediumEquipment = new(intruder.MediumEquipment);
        HeavyEquipment = new(intruder.HeavyEquipment);
        DropEquipmentProbability = intruder.DropEquipmentProbability;
        ComplexionParams = new(
            lengthMm: new(intruder.LengthParams),
            heightMm: new(intruder.HeightParams),
            widthMm: new(intruder.WidthParams));
    }
}

public class EditIntruderDimensionParamsViewModel : ViewModelBase
{
    private int _fullHeightMm;
    private int _deepSquatMm;
    private int _crawlingMm;

    public int FullHeightMm
    {
        get => _fullHeightMm; 
        set
        {
            _fullHeightMm = value;
            OnPropertyChanged();
        }
    }
    public int DeepSquatMm
    {
        get => _deepSquatMm; 
        set
        {
            _deepSquatMm = value;
            OnPropertyChanged();
        }
    }
    public int CrawlingMm
    {
        get => _crawlingMm; 
        set
        {
            _crawlingMm = value;
            OnPropertyChanged();
        }
    }

    public EditIntruderDimensionParamsViewModel(IntruderDimensionsParams? dimensionsParams = null)
    {
        if (dimensionsParams is not null)
        {
            FullHeightMm = dimensionsParams.FullHeightMm;
            DeepSquatMm = dimensionsParams.DeepSquatMm;
            CrawlingMm = dimensionsParams.CrawlingMm;
        }
    }
}

public class EditIntruderComplexionParamsViewModel : ViewModelBase
{
    public EditIntruderDimensionParamsViewModel LengthMm { get; set; } = new();
    public EditIntruderDimensionParamsViewModel HeightMm { get; set; } = new();
    public EditIntruderDimensionParamsViewModel WidthMm { get; set; } = new();

    public EditIntruderComplexionParamsViewModel(
        EditIntruderDimensionParamsViewModel? lengthMm = null,
        EditIntruderDimensionParamsViewModel? heightMm = null,
        EditIntruderDimensionParamsViewModel? widthMm = null)
    {
        if (lengthMm is not null)
        {
            LengthMm = lengthMm;
        }

        if (heightMm is not null)
        {
            HeightMm = heightMm;
        }

        if (widthMm is not null)
        {
            WidthMm = widthMm;
        }
    }
}

public class EditIntruderEquipmentParamsViewModel : ViewModelBase
{
    private bool _isUsed;
    private double _obstacleOvercomeTimeDecreaseCoefficient;
    private double _velocityDecreaseCoefficient;

    public bool IsUsed
    {
        get => _isUsed; 
        set
        {
            _isUsed = value;
            OnPropertyChanged();
            if (!value)
            {
                ObstacleOvercomeTimeDecreaseCoefficient = 0;
                VelocityDecreaseCoefficient = 0;
            }
        }
    }
    public double ObstacleOvercomeTimeDecreaseCoefficient
    {
        get => _obstacleOvercomeTimeDecreaseCoefficient; 
        set
        {
            _obstacleOvercomeTimeDecreaseCoefficient = value;
            OnPropertyChanged();
        }
    }
    public double VelocityDecreaseCoefficient
    {
        get => _velocityDecreaseCoefficient; 
        set
        {
            _velocityDecreaseCoefficient = value;
            OnPropertyChanged();
        }
    }

    public EditIntruderEquipmentParamsViewModel(IntruderEquipmentParams? equipmentParams = null)
    {
        if (equipmentParams is not null)
        {
            IsUsed = equipmentParams.IsUsed;
            ObstacleOvercomeTimeDecreaseCoefficient = equipmentParams.ObstacleOvercomeTimeDecreaseCoefficient;
            VelocityDecreaseCoefficient = equipmentParams.VelocityDecreaseCoefficient;
        }
    }
}

public class EditIntruderPsychophysicalParamsViewModel : ViewModelBase
{
    private double _unnoticedIntrusionProbability;
    private double _cautionDropTo0Probability;
    private double _intrusionRefusalProbability;
    private double _velocityChangeProbability;
    private double _velocityIncreaseProbability;
    private double _movementDirectionChangeProbability;
    private double _minRunawayDistance;
    private double _maxRunawayDistance;
    private int _objectTerritoryKnowledgePercent;
    private double _aerialConstructionIntrusionProbability;

    public double UnnoticedIntrusionProbability
    {
        get => _unnoticedIntrusionProbability; 
        set
        {
            _unnoticedIntrusionProbability = value;
            OnPropertyChanged();
        }
    }
    public double CautionDropTo0Probability
    {
        get => _cautionDropTo0Probability; 
        set
        {
            _cautionDropTo0Probability = value;
            OnPropertyChanged();
        }
    }
    public double IntrusionRefusalProbability
    {
        get => _intrusionRefusalProbability; 
        set
        {
            _intrusionRefusalProbability = value;
            OnPropertyChanged();
        }
    }
    public double VelocityChangeProbability
    {
        get => _velocityChangeProbability; 
        set
        {
            _velocityChangeProbability = value;
            OnPropertyChanged();
        }
    }
    public double VelocityIncreaseProbability
    {
        get => _velocityIncreaseProbability; 
        set
        {
            _velocityIncreaseProbability = value;
            OnPropertyChanged();
        }
    }
    public double MovementDirectionChangeProbability
    {
        get => _movementDirectionChangeProbability; 
        set
        {
            _movementDirectionChangeProbability = value;
            OnPropertyChanged();
        }
    }
    public double MinRunawayDistance
    {
        get => _minRunawayDistance; 
        set
        {
            _minRunawayDistance = value;
            OnPropertyChanged();
        }
    }
    public double MaxRunawayDistance
    {
        get => _maxRunawayDistance; 
        set
        {
            _maxRunawayDistance = value;
            OnPropertyChanged();
        }
    }
    public int ObjectTerritoryKnowledgePercent
    {
        get => _objectTerritoryKnowledgePercent; 
        set
        {
            _objectTerritoryKnowledgePercent = value;
            OnPropertyChanged();
        }
    }
    public double AerialConstructionIntrusionProbability
    {
        get => _aerialConstructionIntrusionProbability; 
        set
        {
            _aerialConstructionIntrusionProbability = value;
            OnPropertyChanged();
        }
    }

    public EditIntruderPsychophysicalParamsViewModel(IntruderPsychophysicalParams? psychophysicalParams = null)
    {
        if (psychophysicalParams is not null)
        {
            UnnoticedIntrusionProbability = psychophysicalParams.UnnoticedIntrusionProbability;
            CautionDropTo0Probability = psychophysicalParams.CautionDropTo0Probability;
            IntrusionRefusalProbability = psychophysicalParams.IntrusionRefusalProbability;
            VelocityChangeProbability = psychophysicalParams.VelocityChangeProbability;
            VelocityIncreaseProbability = psychophysicalParams.VelocityIncreaseProbability;
            MovementDirectionChangeProbability = psychophysicalParams.MovementDirectionChangeProbability;
            MinRunawayDistance = psychophysicalParams.MinRunawayDistance;
            MaxRunawayDistance = psychophysicalParams.MaxRunawayDistance;
        }
    }
}

public class EditIntruderCarParamsViewModel : ViewModelBase
{
    private bool _hasCar;
    private double _velocityIncreaseCoefficient;
    private double _carDropProbability;

    public bool HasCar
    {
        get => _hasCar; 
        set
        {
            _hasCar = value;
            OnPropertyChanged();
            if (!value)
            {
                VelocityIncreaseCoefficient = 0;
                CarDropProbability = 0;
            }
        }
    }

    public double VelocityIncreaseCoefficient
    {
        get => _velocityIncreaseCoefficient; 
        set
        {
            _velocityIncreaseCoefficient = value;
            OnPropertyChanged();
        }
    }

    public double CarDropProbability
    {
        get => _carDropProbability; 
        set
        {
            _carDropProbability = value;
            OnPropertyChanged();
        }
    }

    public EditIntruderCarParamsViewModel(IntruderCarParams? carParams = null)
    {
        if (carParams is not null)
        {
            HasCar = carParams.HasCar;
            VelocityIncreaseCoefficient = carParams.VelocityIncreaseCoefficient;
            CarDropProbability = carParams.CarDropProbability;
        }
    }
}

public class EditIntruderAccomplicesParamsViewModel : ViewModelBase
{
    private bool _hasAccomplices;
    private double _iso2xDelayDropProbability;
    private double _sensors2xDetectionDecreaseProbability;
    private double _timeTillIntentionalFalseAlarm;

    public bool HasAccomplices
    {
        get => _hasAccomplices; 
        set
        {
            _hasAccomplices = value;
            OnPropertyChanged();
            if (!value)
            {
                Iso2xDelayDropProbability = 0;
                Sensors2xDetectionDecreaseProbability = 0;
                TimeTillIntentionalFalseAlarm = 0;
            }
        }
    }

    public double Iso2xDelayDropProbability
    {
        get => _iso2xDelayDropProbability; 
        set
        {
            _iso2xDelayDropProbability = value;
            OnPropertyChanged();
        }
    }

    public double Sensors2xDetectionDecreaseProbability
    {
        get => _sensors2xDetectionDecreaseProbability; 
        set
        {
            _sensors2xDetectionDecreaseProbability = value;
            OnPropertyChanged();
        }
    }

    public double TimeTillIntentionalFalseAlarm
    {
        get => _timeTillIntentionalFalseAlarm; 
        set
        {
            _timeTillIntentionalFalseAlarm = value;
            OnPropertyChanged();
        }
    }

    public EditIntruderAccomplicesParamsViewModel(IntruderAccomplicesParams? accomplicesParams = null)
    {
        if (accomplicesParams is not null)
        {
            HasAccomplices = accomplicesParams.HasAccomplices;
            Iso2xDelayDropProbability = accomplicesParams.Iso2xDelayDropProbability;
            Sensors2xDetectionDecreaseProbability = accomplicesParams.Sensors2xDetectionDecreaseProbability;
            TimeTillIntentionalFalseAlarm = accomplicesParams.TimeTillIntentionalFalseAlarm;
        }
    }
}

public class EditIntruderVelocityParamsViewModel : ViewModelBase
{
    private VelocityMeasureUnits _velocityMeasureUnit;
    private double _minVelocity;
    private double _maxVelocity;
    public static VelocityMeasureUnits[] VelocityMeasureUnits
        => Enum.GetValues<VelocityMeasureUnits>();

    public VelocityMeasureUnits VelocityMeasureUnit
    {
        get => _velocityMeasureUnit; 
        set
        {
            _velocityMeasureUnit = value;
            OnPropertyChanged();
        }
    }

    public double MinVelocity
    {
        get => _minVelocity; 
        set
        {
            _minVelocity = value;
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

    public EditIntruderVelocityParamsViewModel()
    {
    }

    public EditIntruderVelocityParamsViewModel(IntruderVelocityParams velocityParams)
    {
        ArgumentNullException.ThrowIfNull(velocityParams, nameof(velocityParams));
        VelocityMeasureUnit = velocityParams.VelocityMeasureUnit;
        MinVelocity = velocityParams.MinVelocity;
        MaxVelocity = velocityParams.MaxVelocity;
    }
}
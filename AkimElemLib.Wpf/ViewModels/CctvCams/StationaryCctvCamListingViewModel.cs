using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.CctvCams;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.CctvCams;
using AkimElemLib.Wpf.Models.Common;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkimElemLib.Wpf.ViewModels.CctvCams;

public class StationaryCctvCamListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<StationaryCctvCamReadOnlyViewModel> _cams = new();
    private StationaryCctvCamReadOnlyViewModel? _selectedCam;

    public ReadOnlyObservableCollection<StationaryCctvCamReadOnlyViewModel> StationaryCctvCams { get; }
    public AsyncCommandBase LoadStationaryCctvCamsCommand { get; }
    public AsyncCommandBase AddStationaryCctvCamCommand { get; }
    public AsyncCommandBase EditStationaryCctvCamCommand { get; }
    public AsyncCommandBase DeleteStationaryCctvCamCommand { get; }

    public StationaryCctvCamReadOnlyViewModel? SelectedStationaryCctvCam
    {
        get => _selectedCam; 
        set
        {
            _selectedCam = value;
            OnPropertyChanged();
            EditStationaryCctvCamCommand.OnCanExecuteChanged();
            DeleteStationaryCctvCamCommand.OnCanExecuteChanged();
        }
    }

    public StationaryCctvCamListingViewModel(
        IExceptionHandler exceptionHandler,
        AkimElemLibContext context,
        IEditStationaryCctvCamDialogWindowService dialogWindowService)
    {
        StationaryCctvCams = new ReadOnlyObservableCollection<StationaryCctvCamReadOnlyViewModel>(_cams);
        LoadStationaryCctvCamsCommand = new LoadStationaryCctvCamsCommand(exceptionHandler.Handle, this, context);
        AddStationaryCctvCamCommand = new AddStationaryCamCommand(exceptionHandler.Handle, this, context, dialogWindowService);
        EditStationaryCctvCamCommand = new EditStationaryCamCommand(exceptionHandler.Handle, this, context, dialogWindowService);
        DeleteStationaryCctvCamCommand = new DeleteStationaryCamCommand(exceptionHandler.Handle, this, context);
    }

    public void LoadCams(IEnumerable<StationaryCctvCam> cams)
    {
        ArgumentNullException.ThrowIfNull(cams, nameof(cams));
        foreach (var cam in cams)
        {
            _cams.Add(new StationaryCctvCamReadOnlyViewModel(cam));
        }
    }

    public void AddCam(StationaryCctvCam cam)
    {
        ArgumentNullException.ThrowIfNull(cam, nameof(cam));
        _cams.Add(new StationaryCctvCamReadOnlyViewModel(cam));
    }

    public void SetCam(StationaryCctvCam cam, int index)
    {
        ArgumentNullException.ThrowIfNull(cam, nameof(cam));
        _cams[index] = new StationaryCctvCamReadOnlyViewModel(cam);
    }

    public void DeleteSelectedCam()
    {
        _cams.Remove(SelectedStationaryCctvCam!);
    }
}

public class StationaryCctvCamReadOnlyViewModel : ViewModelBase
{
    private readonly StationaryCctvCam _cam;

    public StationaryCctvCamReadOnlyViewModel(StationaryCctvCam cam)
    {
        ArgumentNullException.ThrowIfNull(cam, nameof(cam));
        _cam = cam;
    }

    public Guid Id => _cam.Id;
    public double LightSensitivity => _cam.LightSensitivity;
    public PowerSupplyTypes PowerSupplyType => _cam.PowerSupplyType;
    public double PowerConsumptionWatts => _cam.PowerConsumptionWatts;
    public double WorkingVoltage => _cam.WorkingVoltage;
    public double MatrixDiagonalHorizontal => _cam.MatrixDiagonalHorizontal;
    public double MatrixDiagonalVertical => _cam.MatrixDiagonalVertical;
    public double ImageResolutionHorizontal => _cam.ImageResolutionHorizontal;
    public double ImageResolutionVertical => _cam.ImageResolutionVertical;
    public string VariofocalLensParams => _cam.VariofocalLensParams.ToString();
    public double MinTemperature => _cam.MinTemperature;
    public double MaxTemperature => _cam.MaxTemperature;
    public CctvCamMatrixFormats MatrixFormat => _cam.MatrixFormat;
    public double Omega => _cam.Omega;
    public double Phi => _cam.Phi;
    public double Alpha => _cam.Alpha;
    public double AlphaMin => _cam.AlphaMin;
    public double AlphaMax => _cam.AlphaMax;
    public double Beta => _cam.Beta;
    public double InstallationHeight => _cam.InstallationHeight;
    public bool HasVideoAnalytics => _cam.HasVideoAnalytics;
    public double Fps => _cam.Fps;
    public Probability DetectionProbability => _cam.DetectionProbability;
    public double MinReactionTime => _cam.MinReactionTime;
}
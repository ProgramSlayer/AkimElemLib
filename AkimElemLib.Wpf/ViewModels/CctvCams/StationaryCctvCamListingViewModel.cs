using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.CctvCams;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.CctvCams;
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
        _cams.Clear();
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

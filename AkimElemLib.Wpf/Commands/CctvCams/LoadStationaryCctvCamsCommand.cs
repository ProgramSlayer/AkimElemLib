using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.CctvCams;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.CctvCams;

public class LoadStationaryCctvCamsCommand : AsyncCommandBase
{
    private readonly StationaryCctvCamListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;

    public LoadStationaryCctvCamsCommand(Action<Exception> onException, StationaryCctvCamListingViewModel listingViewModel, AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _listingViewModel = listingViewModel;
        _context = context;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var cams = await _context.StationaryCctvCams
            .AsNoTracking()
            .ToListAsync();
        _listingViewModel.LoadCams(cams);
    }
}

public class AddStationaryCamCommand : AsyncCommandBase
{
    private readonly StationaryCctvCamListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditStationaryCctvCamDialogWindowService _dialogWindowService;

    public AddStationaryCamCommand(
        Action<Exception> onException, 
        StationaryCctvCamListingViewModel 
        listingViewModel, 
        AkimElemLibContext context, 
        IEditStationaryCctvCamDialogWindowService dialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(dialogWindowService, nameof(dialogWindowService));

        _listingViewModel = listingViewModel;
        _context = context;
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var editCamViewModel = new EditStationaryCctvCamViewModel();
        var dialogResult = _dialogWindowService.ShowDialog(editCamViewModel);
        if (dialogResult != true)
        {
            return;
        }

        var cam = editCamViewModel.ToStationaryCctvCam();
        await _context.StationaryCctvCams.AddAsync(cam);
        await _context.SaveChangesAsync();

        _listingViewModel.AddCam(cam);
    }
}

public class EditStationaryCamCommand : AsyncCommandBase
{
    private readonly StationaryCctvCamListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditStationaryCctvCamDialogWindowService _dialogWindowService;

    public EditStationaryCamCommand(
        Action<Exception> onException,
        StationaryCctvCamListingViewModel
        listingViewModel,
        AkimElemLibContext context,
        IEditStationaryCctvCamDialogWindowService dialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(dialogWindowService, nameof(dialogWindowService));

        _listingViewModel = listingViewModel;
        _context = context;
        _dialogWindowService = dialogWindowService;
    }

    public override bool CanExecute(object? parameter) => 
        base.CanExecute(parameter) && 
        _listingViewModel.SelectedStationaryCctvCam is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _listingViewModel.SelectedStationaryCctvCam!.Id;
        var cam = await _context.StationaryCctvCams.FindAsync(id)
            ?? throw new Exception($"Стационарная камера видеонаблюдения (Id: {id}) не найдена.");

        var editCamViewModel = new EditStationaryCctvCamViewModel(cam);

        var dialogResult = _dialogWindowService.ShowDialog(editCamViewModel);
        if (dialogResult != true)
        {
            return;
        }

        editCamViewModel.ToStationaryCctvCam(cam);
        await _context.SaveChangesAsync();

        var index = _listingViewModel.StationaryCctvCams.IndexOf(_listingViewModel.SelectedStationaryCctvCam);
        _listingViewModel.SetCam(cam, index);
    }
}

public class DeleteStationaryCamCommand : AsyncCommandBase
{
    private readonly StationaryCctvCamListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;

    public DeleteStationaryCamCommand(
        Action<Exception> onException,
        StationaryCctvCamListingViewModel
        listingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _listingViewModel = listingViewModel;
        _context = context;
    }

    public override bool CanExecute(object? parameter) =>
        base.CanExecute(parameter) &&
        _listingViewModel.SelectedStationaryCctvCam is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _listingViewModel.SelectedStationaryCctvCam!.Id;
        var cam = await _context.StationaryCctvCams.FindAsync(id)
            ?? throw new Exception($"Стационарная камера видеонаблюдения (Id: {id}) не найдена.");

        _context.StationaryCctvCams.Remove(cam);
        await _context.SaveChangesAsync();

        _listingViewModel.DeleteSelectedCam();
    }
}
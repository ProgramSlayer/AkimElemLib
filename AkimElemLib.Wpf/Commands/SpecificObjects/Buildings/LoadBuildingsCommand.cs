using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.Buildings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.SpecificObjects.Buildings;

public class LoadBuildingsCommand : AsyncCommandBase
{
    private readonly BuildingListingViewModel _buildingListingViewModel;
    private readonly AkimElemLibContext _context;

    public LoadBuildingsCommand(
        Action<Exception> onException,
        BuildingListingViewModel buildingListingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(buildingListingViewModel, nameof(buildingListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _buildingListingViewModel = buildingListingViewModel;
        _context = context;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var buildings = await _context.Buildings
            .AsNoTracking()
            .ToListAsync();
        _buildingListingViewModel.LoadBuildings(buildings);
    }
}

public class AddBuildingCommand : AsyncCommandBase
{
    private readonly BuildingListingViewModel _buildingListingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditBuildingDialogWindowService _editBuildingDialogWindowService;

    public AddBuildingCommand(
        Action<Exception> onException,
        BuildingListingViewModel buildingListingViewModel,
        AkimElemLibContext context,
        IEditBuildingDialogWindowService editBuildingDialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(buildingListingViewModel, nameof(buildingListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editBuildingDialogWindowService, nameof(editBuildingDialogWindowService));

        _buildingListingViewModel = buildingListingViewModel;
        _context = context;
        _editBuildingDialogWindowService = editBuildingDialogWindowService;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var editBuildingViewModel = new EditBuildingViewModel();
        var dialogResult = _editBuildingDialogWindowService.ShowDialog(editBuildingViewModel);

        if (dialogResult != true)
        {
            return;
        }

        var newBuilding = editBuildingViewModel.ToBuilding();
        await _context.Buildings.AddAsync(newBuilding);
        await _context.SaveChangesAsync();

        _buildingListingViewModel.AddBuilding(newBuilding);
    }
}

public class EditBuildingCommand : AsyncCommandBase
{
    private readonly BuildingListingViewModel _buildingListingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditBuildingDialogWindowService _editBuildingDialogWindowService;

    public EditBuildingCommand(
        Action<Exception> onException,
        BuildingListingViewModel buildingListingViewModel,
        AkimElemLibContext context,
        IEditBuildingDialogWindowService editBuildingDialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(buildingListingViewModel, nameof(buildingListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editBuildingDialogWindowService, nameof(editBuildingDialogWindowService));

        _buildingListingViewModel = buildingListingViewModel;
        _context = context;
        _editBuildingDialogWindowService = editBuildingDialogWindowService;
    }

    public override bool CanExecute(object? parameter) => 
        base.CanExecute(parameter) && 
        _buildingListingViewModel.SelectedBuilding is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _buildingListingViewModel.SelectedBuilding!.Id;

        var editBuilding = await _context.Buildings.FindAsync(id)
            ?? throw new Exception($"Строение (Id: {id}) не найдено.");

        var editBuildingViewModel = new EditBuildingViewModel(editBuilding);
        var dialogResult = _editBuildingDialogWindowService.ShowDialog(editBuildingViewModel);

        if (dialogResult != true)
        {
            return;
        }

        editBuildingViewModel.ToBuilding(editBuilding);
        await _context.SaveChangesAsync();

        var index = _buildingListingViewModel.Buildings.IndexOf(_buildingListingViewModel.SelectedBuilding);
        _buildingListingViewModel.SetBuilding(editBuilding, index);
    }
}

public class DeleteBuildingCommand : AsyncCommandBase
{
    private readonly BuildingListingViewModel _buildingListingViewModel;
    private readonly AkimElemLibContext _context;

    public DeleteBuildingCommand(
        Action<Exception> onException,
        BuildingListingViewModel buildingListingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(buildingListingViewModel, nameof(buildingListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _buildingListingViewModel = buildingListingViewModel;
        _context = context;
    }

    public override bool CanExecute(object? parameter) => 
        base.CanExecute(parameter) && 
        _buildingListingViewModel.SelectedBuilding is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _buildingListingViewModel.SelectedBuilding!.Id;

        var deleteBuilding = await _context.Buildings.FindAsync(id)
            ?? throw new Exception($"Строение (Id: {id}) не найдено.");

        _context.Buildings.Remove(deleteBuilding);
        await _context.SaveChangesAsync();

        _buildingListingViewModel.DeleteSelectedBuilding();
    }
}


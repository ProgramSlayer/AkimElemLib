using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.SpecificObjects.Buildings;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.SpecificObjects.Buildings;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkimElemLib.Wpf.ViewModels.SpecificObjects.Buildings;

public class BuildingListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<BuildingReadOnlyViewModel> _buildings = new();
    private BuildingReadOnlyViewModel? _selectedBuilding;

    public ReadOnlyObservableCollection<BuildingReadOnlyViewModel> Buildings { get; }
    public AsyncCommandBase LoadBuildingsCommand { get; }
    public AsyncCommandBase AddBuildingCommand { get; }
    public AsyncCommandBase EditBuildingCommand { get; }
    public AsyncCommandBase DeleteBuildingCommand { get; }

    public BuildingReadOnlyViewModel? SelectedBuilding
    {
        get => _selectedBuilding;
        set
        {
            _selectedBuilding = value;
            OnPropertyChanged();
            EditBuildingCommand.OnCanExecuteChanged();
            DeleteBuildingCommand.OnCanExecuteChanged();
        }
    }

    public BuildingListingViewModel(
        IExceptionHandler exceptionHandler,
        AkimElemLibContext context,
        IEditBuildingDialogWindowService editBuildingDialogWindowService)
    {
        Buildings = new ReadOnlyObservableCollection<BuildingReadOnlyViewModel>(_buildings);
        LoadBuildingsCommand = new LoadBuildingsCommand(exceptionHandler.Handle, this, context);
        AddBuildingCommand = new AddBuildingCommand(exceptionHandler.Handle, this, context, editBuildingDialogWindowService);
        EditBuildingCommand = new EditBuildingCommand(exceptionHandler.Handle, this, context, editBuildingDialogWindowService);
        DeleteBuildingCommand = new DeleteBuildingCommand(exceptionHandler.Handle, this, context);
    }

    public void LoadBuildings(IEnumerable<Building> buildings)
    {
        ArgumentNullException.ThrowIfNull(buildings, nameof(buildings));
        _buildings.Clear();
        foreach (var building in buildings)
        {
            _buildings.Add(new BuildingReadOnlyViewModel(building));
        }
    }

    public void AddBuilding(Building building)
    {
        ArgumentNullException.ThrowIfNull(building, nameof(building));
        _buildings.Add(new BuildingReadOnlyViewModel(building));
    }

    public void SetBuilding(Building building, int index)
    {
        ArgumentNullException.ThrowIfNull(building, nameof(building));
        _buildings[index] = new BuildingReadOnlyViewModel(building);
    }

    public void DeleteSelectedBuilding()
    {
        _buildings.Remove(SelectedBuilding!);
    }
}

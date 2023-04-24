using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.SpecificObjects.SpecificAreas;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.SpecificObjects.SpecificAreas;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkimElemLib.Wpf.ViewModels.SpecificObjects.SpecificAreas;

public class SpecificAreaListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<SpecificAreaReadOnlyViewModel> _specificAreas = new();
    private SpecificAreaReadOnlyViewModel? _selectedSpecificArea;

    public ReadOnlyObservableCollection<SpecificAreaReadOnlyViewModel> SpecificAreas { get; }
    public AsyncCommandBase LoadSpecificAreasCommand { get; }
    public AsyncCommandBase AddSpecificAreaCommand { get; }
    public AsyncCommandBase EditSpecificAreaCommand { get; }
    public AsyncCommandBase DeleteSpecificAreaCommand { get; }

    public SpecificAreaReadOnlyViewModel? SelectedSpecificArea
    {
        get => _selectedSpecificArea; 
        set
        {
            _selectedSpecificArea = value;
            OnPropertyChanged();
            EditSpecificAreaCommand.OnCanExecuteChanged();
            DeleteSpecificAreaCommand.OnCanExecuteChanged();
        }
    }

    public SpecificAreaListingViewModel(
        IExceptionHandler exceptionHandler,
        AkimElemLibContext context,
        IEditSpecificAreaDialogWindowService editSpecificAreaDialogWindowService)
    {
        SpecificAreas = new ReadOnlyObservableCollection<SpecificAreaReadOnlyViewModel>(_specificAreas);
        LoadSpecificAreasCommand = new LoadSpecificAreasCommand(exceptionHandler.Handle, this, context);
        AddSpecificAreaCommand = new AddSpecificAreaCommand(exceptionHandler.Handle, this, context, editSpecificAreaDialogWindowService);
        EditSpecificAreaCommand = new EditSpecificAreaCommand(exceptionHandler.Handle, this, context, editSpecificAreaDialogWindowService);
        DeleteSpecificAreaCommand = new DeleteSpecificAreaCommand(exceptionHandler.Handle, this, context);
    }

    public void LoadSpecificAreas(IEnumerable<SpecificArea> specificAreas)
    {
        ArgumentNullException.ThrowIfNull(specificAreas, nameof(specificAreas));
        _specificAreas.Clear();
        foreach (var specificArea in specificAreas)
        {
            _specificAreas.Add(new SpecificAreaReadOnlyViewModel(specificArea));
        }
    }

    public void AddSpecificArea(SpecificArea specificArea)
    {
        ArgumentNullException.ThrowIfNull(specificArea, nameof(specificArea));
        _specificAreas.Add(new SpecificAreaReadOnlyViewModel(specificArea));
    }

    public void SetSpecificArea(SpecificArea specificArea, int index)
    {
        ArgumentNullException.ThrowIfNull(specificArea, nameof(specificArea));
        _specificAreas[index] = new SpecificAreaReadOnlyViewModel(specificArea);
    }

    public void DeleteSelectedSpecificArea()
    {
        _specificAreas.Remove(SelectedSpecificArea!);
    }
}

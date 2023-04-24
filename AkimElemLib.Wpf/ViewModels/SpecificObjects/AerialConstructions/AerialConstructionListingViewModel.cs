using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkimElemLib.Wpf.ViewModels.SpecificObjects.AerialConstructions;

public class AerialConstructionListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<AerialConstructionReadOnlyViewModel> _aerialConstructions = new();
    private AerialConstructionReadOnlyViewModel? _selectedAerialConstruction;

    public ReadOnlyObservableCollection<AerialConstructionReadOnlyViewModel> AerialConstructions { get; }
    public AsyncCommandBase LoadAerialConstructionsCommand { get; }
    public AsyncCommandBase AddAerialConstructionCommand { get; }
    public AsyncCommandBase EditAerialConstructionCommand { get; }
    public AsyncCommandBase DeleteAerialConstructionCommand { get; }
    public AerialConstructionReadOnlyViewModel? SelectedAerialConstruction
    {
        get => _selectedAerialConstruction; 
        set
        {
            _selectedAerialConstruction = value;
            OnPropertyChanged();
            EditAerialConstructionCommand.OnCanExecuteChanged();
            DeleteAerialConstructionCommand.OnCanExecuteChanged();
        }
    }

    public AerialConstructionListingViewModel(
        IExceptionHandler exceptionHandler,
        AkimElemLibContext context,
        IEditAerialConstructionDialogWindowService editAerialConstructionDialogWindowService)
    {
        ArgumentNullException.ThrowIfNull(exceptionHandler, nameof(exceptionHandler));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editAerialConstructionDialogWindowService, nameof(editAerialConstructionDialogWindowService));

        AerialConstructions = new ReadOnlyObservableCollection<AerialConstructionReadOnlyViewModel>(_aerialConstructions);
        LoadAerialConstructionsCommand = new LoadAerialConstructionsCommand(exceptionHandler.Handle, this, context);
        AddAerialConstructionCommand = new AddAerialConstructionCommand(exceptionHandler.Handle, this, context, editAerialConstructionDialogWindowService);
        EditAerialConstructionCommand = new EditAerialConstructionCommand(exceptionHandler.Handle, this, context, editAerialConstructionDialogWindowService);
        DeleteAerialConstructionCommand = new DeleteAerialConstructionCommand(exceptionHandler.Handle, this, context);
    }

    public void LoadAerialConstructions(IEnumerable<AerialConstruction> aerialConstructions)
    {
        ArgumentNullException.ThrowIfNull(aerialConstructions, nameof(aerialConstructions));
        _aerialConstructions.Clear();
        foreach (var aerialConstruction in aerialConstructions)
        {
            _aerialConstructions.Add(new AerialConstructionReadOnlyViewModel(aerialConstruction));
        }
    }

    public void AddAerialConstruction(AerialConstruction aerialConstruction)
    {
        ArgumentNullException.ThrowIfNull(aerialConstruction, nameof(aerialConstruction));
        _aerialConstructions.Add(new AerialConstructionReadOnlyViewModel(aerialConstruction));
    }

    public void SetAerialConstruction(AerialConstruction aerialConstruction, int index)
    {
        ArgumentNullException.ThrowIfNull(aerialConstruction, nameof(aerialConstruction));
        _aerialConstructions[index] = new AerialConstructionReadOnlyViewModel(aerialConstruction);
    }

    public void DeleteSelectedAerialConstruction()
    {
        _aerialConstructions.Remove(SelectedAerialConstruction!);
    }
}

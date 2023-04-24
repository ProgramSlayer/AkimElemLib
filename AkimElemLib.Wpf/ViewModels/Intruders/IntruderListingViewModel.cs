using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.Intruders;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.Intruders;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkimElemLib.Wpf.ViewModels.Intruders;

public class IntruderListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<IntruderReadOnlyViewModel> _intruders = new();
    private IntruderReadOnlyViewModel? _selectedIntruder;

    public ReadOnlyObservableCollection<IntruderReadOnlyViewModel> Intruders { get; }

    public AsyncCommandBase LoadIntrudersCommand { get; }
    public AsyncCommandBase AddIntruderCommand { get; }
    public AsyncCommandBase EditIntruderCommand { get; }
    public AsyncCommandBase DeleteIntruderCommand { get; }
    public IntruderReadOnlyViewModel? SelectedIntruder
    {
        get => _selectedIntruder; 
        set
        {
            _selectedIntruder = value;
            OnPropertyChanged();
            EditIntruderCommand.OnCanExecuteChanged();
            DeleteIntruderCommand.OnCanExecuteChanged();
        }
    }

    public IntruderListingViewModel(
        IExceptionHandler exceptionHandler,
        AkimElemLibContext context,
        IEditIntruderDialogWindowService editIntruderDialogWindowService)
    {
        ArgumentNullException.ThrowIfNull(exceptionHandler, nameof(exceptionHandler));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editIntruderDialogWindowService, nameof(editIntruderDialogWindowService));

        Intruders = new ReadOnlyObservableCollection<IntruderReadOnlyViewModel>(_intruders);
        LoadIntrudersCommand = new LoadIntrudersCommand(exceptionHandler.Handle, this, context);
        AddIntruderCommand = new AddIntruderCommand(exceptionHandler.Handle, this, context, editIntruderDialogWindowService);
        EditIntruderCommand = new EditIntruderCommand(exceptionHandler.Handle, this, context, editIntruderDialogWindowService);
        DeleteIntruderCommand = new DeleteIntruderCommand(exceptionHandler.Handle, this, context);
    }

    public void LoadIntruders(IEnumerable<Intruder> intruders)
    {
        if (intruders is null)
        {
            throw new ArgumentNullException(nameof(intruders));
        }

        _intruders.Clear();
        foreach (var intruder in intruders)
        {
            _intruders.Add(new IntruderReadOnlyViewModel(intruder));
        }
    }

    public void AddIntruder(Intruder newIntruder)
    {
        ArgumentNullException.ThrowIfNull(newIntruder, nameof(newIntruder));
        _intruders.Add(new IntruderReadOnlyViewModel(newIntruder));
    }

    public void SetIntruder(Intruder intruder, int index)
    {
        _intruders[index] = new IntruderReadOnlyViewModel(intruder);
    }

    public void RemoveSelectedIntruder()
    {
        _intruders.Remove(SelectedIntruder!);
    }
}

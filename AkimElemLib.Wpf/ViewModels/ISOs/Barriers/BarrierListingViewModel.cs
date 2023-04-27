using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.ISOs.Barriers;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.ISOs;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Barriers;

public class BarrierListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<BarrierReadOnlyViewModel> _barriers = new();
    private BarrierReadOnlyViewModel? _selectedBarrier;
    public ReadOnlyObservableCollection<BarrierReadOnlyViewModel> Barriers { get; }
    public AsyncCommandBase LoadBarriersCommand { get; }
    public AsyncCommandBase AddBarrierCommand { get; }
    public AsyncCommandBase EditBarrierCommand { get; }
    public AsyncCommandBase DeleteBarrierCommand { get; }
    public BarrierReadOnlyViewModel? SelectedBarrier
    {
        get => _selectedBarrier; 
        set
        {
            _selectedBarrier = value;
            OnPropertyChanged();
            EditBarrierCommand.OnCanExecuteChanged();
            DeleteBarrierCommand.OnCanExecuteChanged();
        }
    }

    public BarrierListingViewModel(
        IExceptionHandler exceptionHandler,
        AkimElemLibContext context,
        IEditBarrierDialogWindowService dialogWindowService)
    {
        Barriers = new(_barriers);
        LoadBarriersCommand = new LoadBarriersCommand(exceptionHandler.Handle, this, context);
        AddBarrierCommand = new AddBarrierCommand(exceptionHandler.Handle, this, context, dialogWindowService);
        EditBarrierCommand = new EditBarrierCommand(exceptionHandler.Handle, this, context, dialogWindowService);
        DeleteBarrierCommand = new DeleteBarrierCommand(exceptionHandler.Handle, this, context);
    }

    public void LoadBarriers(IEnumerable<Barrier> barriers)
    {
        ArgumentNullException.ThrowIfNull(barriers, nameof(barriers));
        _barriers.Clear();
        foreach (var barrier in barriers)
        {
            _barriers.Add(new(barrier));
        }
    }

    public void AddBarrier(Barrier barrier)
    {
        ArgumentNullException.ThrowIfNull(barrier, nameof(barrier));
        _barriers.Add(new(barrier));
    }

    public void SetBarrier(Barrier barrier, int index)
    {
        ArgumentNullException.ThrowIfNull(barrier, nameof(barrier));
        _barriers[index] = new(barrier);
    }

    public void DeleteSelectedBarrier()
    {
        _barriers.Remove(SelectedBarrier!);
    }
}

using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.ISOs.Fences;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.ISOs;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Fences;

public class FenceListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<FenceReadOnlyViewModel> _fences = new();
    private FenceReadOnlyViewModel? _selectedFence;

    public ReadOnlyObservableCollection<FenceReadOnlyViewModel> Fences { get; }
    public AsyncCommandBase LoadFencesCommand { get; }
    public AsyncCommandBase AddFenceCommand { get; }
    public AsyncCommandBase EditFenceCommand { get; }
    public AsyncCommandBase DeleteFenceCommand { get; }

    public FenceReadOnlyViewModel? SelectedFence
    {
        get => _selectedFence; 
        set
        {
            _selectedFence = value;
            OnPropertyChanged();
            EditFenceCommand.OnCanExecuteChanged();
            DeleteFenceCommand.OnCanExecuteChanged();
        }
    }

    public FenceListingViewModel(
        IExceptionHandler exceptionHandler,
        AkimElemLibContext context, 
        IEditFenceDialogWindowService dialogWindowService)
    {
        Fences = new(_fences);
        LoadFencesCommand = new LoadFencesCommand(exceptionHandler.Handle, this, context);
        AddFenceCommand = new AddFenceCommand(exceptionHandler.Handle, this, context, dialogWindowService);
        EditFenceCommand = new EditFenceCommand(exceptionHandler.Handle, this, context, dialogWindowService);
        DeleteFenceCommand = new DeleteFenceCommand(exceptionHandler.Handle, this, context);
    }

    public void LoadFences(IEnumerable<Fence> fences)
    {
        ArgumentNullException.ThrowIfNull(fences, nameof(fences));
        foreach (var fence in fences)
        {
            _fences.Add(new(fence));
        }
    }

    public void AddFence(Fence fence)
    {
        ArgumentNullException.ThrowIfNull(fence, nameof(fence));
        _fences.Add(new(fence));
    }

    public void SetFence(Fence fence, int index)
    {
        ArgumentNullException.ThrowIfNull(fence, nameof(fence));
        _fences[index] = new(fence);
    }

    public void DeleteSelectedFence()
    {
        _fences.Remove(SelectedFence!);
    }
}

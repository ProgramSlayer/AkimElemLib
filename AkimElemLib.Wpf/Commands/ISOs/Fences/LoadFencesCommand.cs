using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.ISOs.Fences;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.ISOs.Fences;

public class LoadFencesCommand : AsyncCommandBase
{
    private readonly FenceListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;

    public LoadFencesCommand(
        Action<Exception> onException,
        FenceListingViewModel listingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _listingViewModel = listingViewModel;
        _context = context;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var fences = await _context.Fences
            .AsNoTracking()
            .ToListAsync();
        _listingViewModel.LoadFences(fences);
    }
}

public class AddFenceCommand : AsyncCommandBase
{
    private readonly FenceListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditFenceDialogWindowService _dialogWindowService;

    public AddFenceCommand(
        Action<Exception> onException,
        FenceListingViewModel listingViewModel,
        AkimElemLibContext context,
        IEditFenceDialogWindowService dialogWindowService) : base(onException)
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
        var editFenceViewModel = new EditFenceViewModel();
        var dialogResult = _dialogWindowService.ShowDialog(editFenceViewModel);
        if (dialogResult != true)
        {
            return;
        }

        var newFence = editFenceViewModel.ToFence();
        await _context.Fences.AddAsync(newFence);
        await _context.SaveChangesAsync();

        _listingViewModel.AddFence(newFence);
    }
}

public class EditFenceCommand : AsyncCommandBase
{
    private readonly FenceListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditFenceDialogWindowService _dialogWindowService;

    public EditFenceCommand(
        Action<Exception> onException,
        FenceListingViewModel listingViewModel,
        AkimElemLibContext context,
        IEditFenceDialogWindowService dialogWindowService) : base(onException)
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
        _listingViewModel.SelectedFence is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _listingViewModel.SelectedFence!.Id;

        var fence = await _context.Fences.FindAsync(id)
            ?? throw new Exception($"Ограждение (Id: {id}) не найдено.");

        var editFenceViewModel = new EditFenceViewModel(fence);
        var dialogResult = _dialogWindowService.ShowDialog(editFenceViewModel);

        if (dialogResult != true)
        {
            return;
        }

        editFenceViewModel.ToFence(fence);
        await _context.SaveChangesAsync();

        var index = _listingViewModel.Fences.IndexOf(_listingViewModel.SelectedFence);
        _listingViewModel.SetFence(fence, index);
    }
}


public class DeleteFenceCommand : AsyncCommandBase
{
    private readonly FenceListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;

    public DeleteFenceCommand(
        Action<Exception> onException,
        FenceListingViewModel listingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _listingViewModel = listingViewModel;
        _context = context;
    }

    public override bool CanExecute(object? parameter) => 
        base.CanExecute(parameter) &&
        _listingViewModel.SelectedFence is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _listingViewModel.SelectedFence!.Id;

        var fence = await _context.Fences.FindAsync(id)
            ?? throw new Exception($"Ограждение (Id: {id}) не найдено.");

        _context.Fences.Remove(fence);
        await _context.SaveChangesAsync();

        _listingViewModel.DeleteSelectedFence();
    }
}

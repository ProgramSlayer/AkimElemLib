using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.ISOs.Barriers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.ISOs.Barriers;

public class LoadBarriersCommand : AsyncCommandBase
{
    private readonly BarrierListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;

    public LoadBarriersCommand(
        Action<Exception> onException,
        BarrierListingViewModel listingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _listingViewModel = listingViewModel;
        _context = context;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var barriers = await _context.Barriers
            .AsNoTracking()
            .ToListAsync();
        _listingViewModel.LoadBarriers(barriers);
    }
}

public class AddBarrierCommand : AsyncCommandBase
{
    private readonly BarrierListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditBarrierDialogWindowService _dialogWindowService;

    public AddBarrierCommand(
        Action<Exception> onException,
        BarrierListingViewModel listingViewModel,
        AkimElemLibContext context,
        IEditBarrierDialogWindowService dialogWindowService) : base(onException)
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
        var editBarrierViewModel = new EditBarrierViewModel();
        var dialogResult = _dialogWindowService.ShowDialog(editBarrierViewModel);
        if (dialogResult != true)
        {
            return;
        }

        var newBarrier = editBarrierViewModel.ToBarrier();
        await _context.Barriers.AddAsync(newBarrier);
        await _context.SaveChangesAsync();

        _listingViewModel.AddBarrier(newBarrier);
    }
}

public class EditBarrierCommand : AsyncCommandBase
{
    private readonly BarrierListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditBarrierDialogWindowService _dialogWindowService;

    public EditBarrierCommand(
        Action<Exception> onException,
        BarrierListingViewModel listingViewModel,
        AkimElemLibContext context,
        IEditBarrierDialogWindowService dialogWindowService) : base(onException)
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
        _listingViewModel.SelectedBarrier is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _listingViewModel.SelectedBarrier!.Id;
        var barrier = await _context.Barriers.FindAsync(id)
            ?? throw new Exception($"Барьер (Id: {id}) не найден.");

        var editBarrierViewModel = new EditBarrierViewModel(barrier);
        var dialogResult = _dialogWindowService.ShowDialog(editBarrierViewModel);

        if (dialogResult != true)
        {
            return;
        }

        editBarrierViewModel.ToBarrier(barrier);
        await _context.SaveChangesAsync();

        var index = _listingViewModel.Barriers.IndexOf(_listingViewModel.SelectedBarrier);
        _listingViewModel.SetBarrier(barrier, index);
    }
}

public class DeleteBarrierCommand : AsyncCommandBase
{
    private readonly BarrierListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;

    public DeleteBarrierCommand(
        Action<Exception> onException,
        BarrierListingViewModel listingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _listingViewModel = listingViewModel;
        _context = context;
    }

    public override bool CanExecute(object? parameter) => 
        base.CanExecute(parameter) &&
        _listingViewModel.SelectedBarrier is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _listingViewModel.SelectedBarrier!.Id;
        var barrier = await _context.Barriers.FindAsync(id)
            ?? throw new Exception($"Барьер (Id: {id}) не найден.");

        _context.Remove(barrier);
        await _context.SaveChangesAsync();

        _listingViewModel.DeleteSelectedBarrier();
    }
}


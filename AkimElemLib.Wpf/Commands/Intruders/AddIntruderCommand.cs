using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.Intruders;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.Intruders;

public class AddIntruderCommand : AsyncCommandBase
{
    private readonly IntruderListingViewModel _intruderListingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditIntruderDialogWindowService _editIntruderDialogWindowService;

    public AddIntruderCommand(
        Action<Exception> onException,
        IntruderListingViewModel intruderListingViewModel,
        AkimElemLibContext context,
        IEditIntruderDialogWindowService editIntruderDialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(intruderListingViewModel, nameof(intruderListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editIntruderDialogWindowService, nameof(editIntruderDialogWindowService));

        _intruderListingViewModel = intruderListingViewModel;
        _context = context;
        _editIntruderDialogWindowService = editIntruderDialogWindowService;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var editIntruderViewModel = new EditIntruderViewModel();
        var dialogResult = _editIntruderDialogWindowService.ShowDialog(editIntruderViewModel);

        if (dialogResult != true)
        {
            return;
        }

        var newIntruder = editIntruderViewModel.ToIntruder();
        await _context.Intruders.AddAsync(newIntruder);
        await _context.SaveChangesAsync();

        _intruderListingViewModel.AddIntruder(newIntruder);
    }
}

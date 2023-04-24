using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.Intruders;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.Intruders;

public class EditIntruderCommand : AsyncCommandBase
{
    private readonly IntruderListingViewModel _intruderListingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditIntruderDialogWindowService _editIntruderDialogWindowService;

    public EditIntruderCommand(
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

    public override bool CanExecute(object? parameter) =>
        base.CanExecute(parameter) &&
        _intruderListingViewModel.SelectedIntruder is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var intruderToEdit = await _context.Intruders.FindAsync(_intruderListingViewModel.SelectedIntruder!.Id) ??
            throw new Exception($"Нарушитель (Id: {_intruderListingViewModel.SelectedIntruder!.Id}) не найден.");

        var editIntruderViewModel = new EditIntruderViewModel(intruderToEdit);

        var dialogResult = _editIntruderDialogWindowService.ShowDialog(editIntruderViewModel);

        if (dialogResult != true)
        {
            return;
        }

        editIntruderViewModel.ToIntruder(intruderToEdit);
        await _context.SaveChangesAsync();

        var indexOf = _intruderListingViewModel.Intruders.IndexOf(_intruderListingViewModel.SelectedIntruder);
        _intruderListingViewModel.SetIntruder(intruderToEdit, indexOf);
    }
}

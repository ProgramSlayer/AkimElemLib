using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.ViewModels.Intruders;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.Intruders;

public class DeleteIntruderCommand : AsyncCommandBase
{
    private readonly IntruderListingViewModel _intruderListingViewModel;
    private readonly AkimElemLibContext _context;

    public DeleteIntruderCommand(
        Action<Exception> onException,
        IntruderListingViewModel intruderListingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(intruderListingViewModel, nameof(intruderListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _intruderListingViewModel = intruderListingViewModel;
        _context = context;
    }

    public override bool CanExecute(object? parameter) =>
        base.CanExecute(parameter) &&
        _intruderListingViewModel.SelectedIntruder is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _intruderListingViewModel.SelectedIntruder!.Id;

        var deleteIntruder = await _context.Intruders.FindAsync(id) ??
            throw new Exception($"Нарушитель (Id: {id}) не найден.");

        _context.Intruders.Remove(deleteIntruder);
        await _context.SaveChangesAsync();

        _intruderListingViewModel.RemoveSelectedIntruder();
    }
}
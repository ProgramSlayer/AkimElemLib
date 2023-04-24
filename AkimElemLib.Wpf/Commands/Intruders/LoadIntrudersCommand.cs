using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.ViewModels.Intruders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.Intruders;

public class LoadIntrudersCommand : AsyncCommandBase
{
    private readonly IntruderListingViewModel _intruderListingViewModel;
    private readonly AkimElemLibContext _context;

    public LoadIntrudersCommand(
        Action<Exception> onException,
        IntruderListingViewModel intruderListingViewModel,
        AkimElemLibContext context)
        : base(onException)
    {
        ArgumentNullException.ThrowIfNull(intruderListingViewModel, nameof(intruderListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _intruderListingViewModel = intruderListingViewModel;
        _context = context;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var intruders = await _context.Intruders
            .AsNoTracking()
            .ToListAsync();
        _intruderListingViewModel.LoadIntruders(intruders);
    }
}

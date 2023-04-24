using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.SpecificAreas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.SpecificObjects.SpecificAreas;

public class LoadSpecificAreasCommand : AsyncCommandBase
{
    private readonly SpecificAreaListingViewModel _specificAreaListingViewModel;
    private readonly AkimElemLibContext _context;

    public LoadSpecificAreasCommand(
        Action<Exception> onException,
        SpecificAreaListingViewModel specificAreaListingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(specificAreaListingViewModel, nameof(specificAreaListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _specificAreaListingViewModel = specificAreaListingViewModel;
        _context = context;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var specificAreas = await _context.SpecificAreas
            .AsNoTracking()
            .ToListAsync();
        _specificAreaListingViewModel.LoadSpecificAreas(specificAreas.AsEnumerable());
    }
}

public class AddSpecificAreaCommand : AsyncCommandBase
{
    private readonly SpecificAreaListingViewModel _specificAreaListingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditSpecificAreaDialogWindowService _editSpecificAreaDialogWindowService;

    public AddSpecificAreaCommand(
        Action<Exception> onException,
        SpecificAreaListingViewModel specificAreaListingViewModel,
        AkimElemLibContext context,
        IEditSpecificAreaDialogWindowService editSpecificAreaDialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(specificAreaListingViewModel, nameof(specificAreaListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editSpecificAreaDialogWindowService, nameof(editSpecificAreaDialogWindowService));

        _specificAreaListingViewModel = specificAreaListingViewModel;
        _context = context;
        _editSpecificAreaDialogWindowService = editSpecificAreaDialogWindowService;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var editSpecificAreaViewModel = new EditSpecificAreaViewModel();
        var dialogResult = _editSpecificAreaDialogWindowService.ShowDialog(editSpecificAreaViewModel);

        if (dialogResult != true)
        {
            return;
        }

        var newSpecificArea = editSpecificAreaViewModel.ToSpecificArea();
        await _context.SpecificAreas.AddAsync(newSpecificArea);
        await _context.SaveChangesAsync();

        _specificAreaListingViewModel.AddSpecificArea(newSpecificArea);
    }
}

public class EditSpecificAreaCommand : AsyncCommandBase
{
    private readonly SpecificAreaListingViewModel _specificAreaListingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditSpecificAreaDialogWindowService _editSpecificAreaDialogWindowService;

    public EditSpecificAreaCommand(
        Action<Exception> onException,
        SpecificAreaListingViewModel specificAreaListingViewModel,
        AkimElemLibContext context,
        IEditSpecificAreaDialogWindowService editSpecificAreaDialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(specificAreaListingViewModel, nameof(specificAreaListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editSpecificAreaDialogWindowService, nameof(editSpecificAreaDialogWindowService));

        _specificAreaListingViewModel = specificAreaListingViewModel;
        _context = context;
        _editSpecificAreaDialogWindowService = editSpecificAreaDialogWindowService;
    }

    public override bool CanExecute(object? parameter) => 
        base.CanExecute(parameter) && 
        _specificAreaListingViewModel.SelectedSpecificArea is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _specificAreaListingViewModel.SelectedSpecificArea!.Id;

        var editSpecificArea = await _context.SpecificAreas.FindAsync(id)
            ?? throw new Exception($"Специфический участок (Id: {id}) не найден.");

        var editSpecificAreaViewModel = new EditSpecificAreaViewModel(editSpecificArea);
        var dialogResult = _editSpecificAreaDialogWindowService.ShowDialog(editSpecificAreaViewModel);

        if (dialogResult != true)
        {
            return;
        }

        editSpecificAreaViewModel.ToSpecificArea(editSpecificArea);
        await _context.SaveChangesAsync();

        var index = _specificAreaListingViewModel.SpecificAreas.IndexOf(_specificAreaListingViewModel.SelectedSpecificArea);
        _specificAreaListingViewModel.SetSpecificArea(editSpecificArea, index);
    }
}

public class DeleteSpecificAreaCommand : AsyncCommandBase
{
    private readonly SpecificAreaListingViewModel _specificAreaListingViewModel;
    private readonly AkimElemLibContext _context;

    public DeleteSpecificAreaCommand(
        Action<Exception> onException,
        SpecificAreaListingViewModel specificAreaListingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(specificAreaListingViewModel, nameof(specificAreaListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _specificAreaListingViewModel = specificAreaListingViewModel;
        _context = context;
    }

    public override bool CanExecute(object? parameter) =>
        base.CanExecute(parameter) &&
        _specificAreaListingViewModel.SelectedSpecificArea is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _specificAreaListingViewModel.SelectedSpecificArea!.Id;

        var deleteSpecificArea = await _context.SpecificAreas.FindAsync(id)
            ?? throw new Exception($"Специфический участок (Id: {id}) не найден.");

        _context.SpecificAreas.Remove(deleteSpecificArea);
        await _context.SaveChangesAsync();

        _specificAreaListingViewModel.DeleteSelectedSpecificArea();
    }
}

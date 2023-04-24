using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.AerialConstructions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.SpecificObjects.AerialConstructions;

public class LoadAerialConstructionsCommand : AsyncCommandBase
{
    private readonly AerialConstructionListingViewModel _aerialConstructionListingViewModel;
    private readonly AkimElemLibContext _context;

    public LoadAerialConstructionsCommand(
        Action<Exception> onException, 
        AerialConstructionListingViewModel aerialConstructionListingViewModel, 
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(aerialConstructionListingViewModel, nameof(aerialConstructionListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _aerialConstructionListingViewModel = aerialConstructionListingViewModel;
        _context = context;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var aerialConstructions = await _context.AerialConstructions
            .AsNoTracking()
            .ToListAsync();
        _aerialConstructionListingViewModel.LoadAerialConstructions(aerialConstructions);
    }
}

public class AddAerialConstructionCommand : AsyncCommandBase
{
    private readonly AerialConstructionListingViewModel _aerialConstructionListingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditAerialConstructionDialogWindowService _editAerialConstructionDialogWindowService;

    public AddAerialConstructionCommand(
        Action<Exception> onException,
        AerialConstructionListingViewModel aerialConstructionListingViewModel,
        AkimElemLibContext context,
        IEditAerialConstructionDialogWindowService editAerialConstructionDialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(aerialConstructionListingViewModel, nameof(aerialConstructionListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editAerialConstructionDialogWindowService, nameof(editAerialConstructionDialogWindowService));

        _aerialConstructionListingViewModel = aerialConstructionListingViewModel;
        _context = context;
        _editAerialConstructionDialogWindowService = editAerialConstructionDialogWindowService;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var editAerialConstructionViewModel = new EditAerialConstructionViewModel();
        var dialogResult = _editAerialConstructionDialogWindowService.ShowDialog(editAerialConstructionViewModel);

        if (dialogResult != true)
        {
            return;
        }

        var newAerialConstruction = editAerialConstructionViewModel.ToAerialConstruction();
        await _context.AerialConstructions.AddAsync(newAerialConstruction);
        await _context.SaveChangesAsync();

        _aerialConstructionListingViewModel.AddAerialConstruction(newAerialConstruction);
    }
}

public class EditAerialConstructionCommand : AsyncCommandBase
{
    private readonly AerialConstructionListingViewModel _aerialConstructionListingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditAerialConstructionDialogWindowService _editAerialConstructionDialogWindowService;

    public EditAerialConstructionCommand(
        Action<Exception> onException,
        AerialConstructionListingViewModel aerialConstructionListingViewModel,
        AkimElemLibContext context,
        IEditAerialConstructionDialogWindowService editAerialConstructionDialogWindowService) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(aerialConstructionListingViewModel, nameof(aerialConstructionListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(editAerialConstructionDialogWindowService, nameof(editAerialConstructionDialogWindowService));

        _aerialConstructionListingViewModel = aerialConstructionListingViewModel;
        _context = context;
        _editAerialConstructionDialogWindowService = editAerialConstructionDialogWindowService;
    }

    public override bool CanExecute(object? parameter) => 
        base.CanExecute(parameter) &&
        _aerialConstructionListingViewModel.SelectedAerialConstruction is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _aerialConstructionListingViewModel.SelectedAerialConstruction!.Id;

        var editAerialConstruction = await _context.AerialConstructions.FindAsync(id) 
            ?? throw new Exception($"Воздушная конструкция (Id: {id}) не найдена.");

        var editAerialConstructionViewModel = new EditAerialConstructionViewModel(editAerialConstruction);
        var dialogResult = _editAerialConstructionDialogWindowService.ShowDialog(editAerialConstructionViewModel);

        if (dialogResult != true)
        {
            return;
        }

        editAerialConstructionViewModel.ToAerialConstruction(editAerialConstruction);
        await _context.SaveChangesAsync();

        var index = _aerialConstructionListingViewModel.AerialConstructions.IndexOf(_aerialConstructionListingViewModel.SelectedAerialConstruction);
        _aerialConstructionListingViewModel.SetAerialConstruction(editAerialConstruction, index);
    }
}

public class DeleteAerialConstructionCommand : AsyncCommandBase
{
    private readonly AerialConstructionListingViewModel _aerialConstructionListingViewModel;
    private readonly AkimElemLibContext _context;

    public DeleteAerialConstructionCommand(
        Action<Exception> onException,
        AerialConstructionListingViewModel aerialConstructionListingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(aerialConstructionListingViewModel, nameof(aerialConstructionListingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _aerialConstructionListingViewModel = aerialConstructionListingViewModel;
        _context = context;
    }

    public override bool CanExecute(object? parameter) =>
        base.CanExecute(parameter) &&
        _aerialConstructionListingViewModel.SelectedAerialConstruction is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _aerialConstructionListingViewModel.SelectedAerialConstruction!.Id;

        var deleteAerialConstruction = await _context.AerialConstructions.FindAsync(id)
            ?? throw new Exception($"Воздушная конструкция (Id: {id}) не найдена.");

        _context.AerialConstructions.Remove(deleteAerialConstruction);
        await _context.SaveChangesAsync();

        _aerialConstructionListingViewModel.DeleteSelectedAerialConstruction();
    }
}

using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Extensions;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.ViewModels.ISOs.Obstacles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands.ISOs.Obstacles;

public class LoadObstaclesCommand : AsyncCommandBase
{
    private readonly ObstacleListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;

    public LoadObstaclesCommand(
        Action<Exception> onException,
        ObstacleListingViewModel listingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _listingViewModel = listingViewModel;
        _context = context;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var obstacles = await _context.Obstacles
            .AsNoTracking()
            .ToListAsync();
        _listingViewModel.LoadObstacles(obstacles);
    }
}

public class AddObstacleCommand : AsyncCommandBase
{
    private readonly ObstacleListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditObstacleDialogWindowService _dialogWindowService;

    public AddObstacleCommand(
        Action<Exception> onException,
        ObstacleListingViewModel listingViewModel,
        AkimElemLibContext context,
        IEditObstacleDialogWindowService dialogWindowService) : base(onException)
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
        var editObstacleViewModel = new EditObstacleViewModel();
        var dialogResult = _dialogWindowService.ShowDialog(editObstacleViewModel);
        if (dialogResult != true)
        {
            return;
        }

        var newObstacle = editObstacleViewModel.ToObstacle();
        await _context.Obstacles.AddAsync(newObstacle);
        await _context.SaveChangesAsync();

        _listingViewModel.AddObstacle(newObstacle);
    }
}

public class EditObstacleCommand : AsyncCommandBase
{
    private readonly ObstacleListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;
    private readonly IEditObstacleDialogWindowService _dialogWindowService;

    public EditObstacleCommand(
        Action<Exception> onException,
        ObstacleListingViewModel listingViewModel,
        AkimElemLibContext context,
        IEditObstacleDialogWindowService dialogWindowService) : base(onException)
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
        _listingViewModel.SelectedObstacle is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _listingViewModel.SelectedObstacle!.Id;
        var obstacle = await _context.Obstacles.FindAsync(id)
            ?? throw new Exception($"Препятствие (Id: {id}) не найдено.");

        var editObstacleViewModel = new EditObstacleViewModel(obstacle);
        var dialogResult = _dialogWindowService.ShowDialog(editObstacleViewModel);
        if (dialogResult != true)
        {
            return;
        }

        editObstacleViewModel.ToObstacle(obstacle);
        await _context.SaveChangesAsync();

        var index = _listingViewModel.Obstacles.IndexOf(_listingViewModel.SelectedObstacle);
        _listingViewModel.SetObstacle(obstacle, index);
    }
}

public class DeleteObstacleCommand : AsyncCommandBase
{
    private readonly ObstacleListingViewModel _listingViewModel;
    private readonly AkimElemLibContext _context;

    public DeleteObstacleCommand(
        Action<Exception> onException,
        ObstacleListingViewModel listingViewModel,
        AkimElemLibContext context) : base(onException)
    {
        ArgumentNullException.ThrowIfNull(listingViewModel, nameof(listingViewModel));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        _listingViewModel = listingViewModel;
        _context = context;
    }

    public override bool CanExecute(object? parameter) => 
        base.CanExecute(parameter) &&
        _listingViewModel.SelectedObstacle is not null;

    public override async Task ExecuteAsync(object? parameter)
    {
        var id = _listingViewModel.SelectedObstacle!.Id;
        var obstacle = await _context.Obstacles.FindAsync(id)
            ?? throw new Exception($"Препятствие (Id: {id}) не найдено.");

        _context.Obstacles.Remove(obstacle);
        await _context.SaveChangesAsync();

        _listingViewModel.DeleteSelectedObstacle();
    }
}

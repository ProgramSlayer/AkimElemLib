using AkimElemLib.Wpf.Commands;
using AkimElemLib.Wpf.Commands.ISOs.Obstacles;
using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Models.ISOs;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkimElemLib.Wpf.ViewModels.ISOs.Obstacles;

public class ObstacleListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<ObstacleReadOnlyViewModel> _obstacles = new();
    private ObstacleReadOnlyViewModel? _selectedObstacle;

    public ReadOnlyObservableCollection<ObstacleReadOnlyViewModel> Obstacles { get; }
    public AsyncCommandBase LoadObstaclesCommand { get; }
    public AsyncCommandBase AddObstacleCommand { get; }
    public AsyncCommandBase EditObstacleCommand { get; }
    public AsyncCommandBase DeleteObstacleCommand { get; }
    public ObstacleReadOnlyViewModel? SelectedObstacle
    {
        get => _selectedObstacle; 
        set
        {
            _selectedObstacle = value;
            OnPropertyChanged();
            EditObstacleCommand.OnCanExecuteChanged();
            DeleteObstacleCommand.OnCanExecuteChanged();
        }
    }

    public ObstacleListingViewModel(
        IExceptionHandler exceptionHandler,
        AkimElemLibContext context,
        IEditObstacleDialogWindowService dialogWindowService)
    {
        Obstacles = new(_obstacles);
        LoadObstaclesCommand = new LoadObstaclesCommand(exceptionHandler.Handle, this, context);
        AddObstacleCommand = new AddObstacleCommand(exceptionHandler.Handle, this, context, dialogWindowService);
        EditObstacleCommand = new EditObstacleCommand(exceptionHandler.Handle, this, context, dialogWindowService);
        DeleteObstacleCommand = new DeleteObstacleCommand(exceptionHandler.Handle, this, context);
    }

    public void LoadObstacles(IEnumerable<Obstacle> obstacles)
    {
        ArgumentNullException.ThrowIfNull(obstacles, nameof(obstacles));
        _obstacles.Clear();
        foreach (var obstacle in obstacles)
        {
            _obstacles.Add(new(obstacle));
        }
    }

    public void AddObstacle(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle, nameof(obstacle));
        _obstacles.Add(new(obstacle));
    }

    public void SetObstacle(Obstacle obstacle, int index)
    {
        ArgumentNullException.ThrowIfNull(obstacle, nameof(obstacle));
        _obstacles[index] = new(obstacle);
    }

    public void DeleteSelectedObstacle()
    {
        _obstacles.Remove(SelectedObstacle!);
    }
}

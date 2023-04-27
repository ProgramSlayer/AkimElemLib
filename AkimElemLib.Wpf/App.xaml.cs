using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Services.DialogWindowServices;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using AkimElemLib.Wpf.ViewModels;
using AkimElemLib.Wpf.ViewModels.CctvCams;
using AkimElemLib.Wpf.ViewModels.Intruders;
using AkimElemLib.Wpf.ViewModels.ISOs.Barriers;
using AkimElemLib.Wpf.ViewModels.ISOs.Fences;
using AkimElemLib.Wpf.ViewModels.ISOs.Obstacles;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.Buildings;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.SpecificAreas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AkimElemLib.Wpf;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    private const string ConnectionString = @"data source = akim_elem_lib.db";

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddDbContext<AkimElemLibContext>(o => o.UseSqlite(ConnectionString));

                services.AddSingleton<IEditIntruderDialogWindowService, EditIntruderDialogWindowService>();
                services.AddSingleton<IEditStationaryCctvCamDialogWindowService, EditStationaryCctvCamDialogWindowService>();
                services.AddSingleton<IEditSpecificAreaDialogWindowService, EditSpecificAreaDialogWindowService>();
                services.AddSingleton<IEditBuildingDialogWindowService, EditBuildingDialogWindowService>();
                services.AddSingleton<IEditAerialConstructionDialogWindowService, EditAerialConstructionDialogWindowService>();
                services.AddSingleton<IEditBarrierDialogWindowService, EditBarrierDialogWindowService>();
                services.AddSingleton<IEditFenceDialogWindowService, EditFenceDialogWindowService>();
                services.AddSingleton<IEditObstacleDialogWindowService, EditObstacleDialogWindowService>();

                services.AddSingleton<IExceptionHandler, MessageBoxExceptionHandler>();

                services.AddSingleton<IntruderListingViewModel>();
                services.AddSingleton<SpecificAreaListingViewModel>();
                services.AddSingleton<BuildingListingViewModel>();
                services.AddSingleton<AerialConstructionListingViewModel>();
                services.AddSingleton<StationaryCctvCamListingViewModel>();
                services.AddSingleton<BarrierListingViewModel>();
                services.AddSingleton<FenceListingViewModel>();
                services.AddSingleton<ObstacleListingViewModel>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton(services => new MainWindow()
                {
                    DataContext = services.GetRequiredService<MainViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                });
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var context = AppHost.Services.GetRequiredService<AkimElemLibContext>();
        context.Database.EnsureDeleted();
        context.Database.Migrate();

        var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
    }
}

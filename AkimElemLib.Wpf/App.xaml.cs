using AkimElemLib.Wpf.DataAccess.Context;
using AkimElemLib.Wpf.Services.DialogWindowServices;
using AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;
using AkimElemLib.Wpf.Services.ExceptionHandlers;
using AkimElemLib.Wpf.ViewModels;
using AkimElemLib.Wpf.ViewModels.CctvCams;
using AkimElemLib.Wpf.ViewModels.Intruders;
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
                services.AddSingleton<IExceptionHandler, MessageBoxExceptionHandler>();

                services.AddSingleton<IntruderListingViewModel>();
                services.AddSingleton<SpecificAreaListingViewModel>();
                services.AddSingleton<BuildingListingViewModel>();
                services.AddSingleton<AerialConstructionListingViewModel>();
                services.AddSingleton<StationaryCctvCamListingViewModel>();
                services.AddSingleton<MainViewModel>();
                //services.AddSingleton(services => new MainViewModel(
                //    services.GetRequiredService<IntruderListingViewModel>(),
                //    services.GetRequiredService<SpecificAreaListingViewModel>(),
                //    services.GetRequiredService<BuildingListingViewModel>(),
                //    services.GetRequiredService<AerialConstructionListingViewModel>()));

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

        //context.SpecificAreas.Add(
        //    new SpecificArea
        //    {
        //        Name = "Test Specific Area",
        //        Height = 100,
        //        HeightRelativeToGround = 50,
        //        MaxVelocity = 100,
        //        Transparency = 100,
        //        VelocityMeasureUnit = VelocityMeasureUnits.MetersPerSecond,
        //    });
        //context.Buildings.Add(
        //    new Building
        //    {
        //        Name = "Test Building",
        //        Height = 20,
        //        HeightRelativeToGround = 10,
        //        MaxVelocity = 10,
        //        Transparency = 50,
        //        VelocityMeasureUnit = VelocityMeasureUnits.MilesPerHour,
        //    });
        //context.AerialConstructions.Add(
        //    new AerialConstruction
        //    {
        //        Name = "Test Aerial Construction",
        //        Height = 30,
        //        HeightRelativeToGround = 15,
        //        MaxVelocity = 15,
        //        Transparency = 65,
        //        VelocityMeasureUnit = VelocityMeasureUnits.KilometersPerHour,
        //    });
        //context.SaveChanges();

        //context.Intruders.Add(new Models.Intruders.Intruder
        //{
        //    AccomplicesParams = new(true, 0.5, 0.5, 3),
        //    CarParams = new(true, 3.5, 0.2),
        //    LightEquipment = new(false, 0, 0),
        //    MediumEquipment = new(false, 0, 0),
        //    HeavyEquipment = new(true, 2, 2),
        //    DropEquipmentProbability = 0.66,
        //    LengthParams = new(110, 110, 110),
        //    HeightParams = new(110, 110, 110),
        //    WidthParams = new(110, 110, 110),
        //    PsychophysicalParams = new(
        //        0.7,
        //        0.1,
        //        0.004,
        //        1,
        //        0.66,
        //        0.3,
        //        12,
        //        45,
        //        56,
        //        0.1),
        //    VelocityParams = new(Models.Common.VelocityMeasureUnits.MetersPerSecond, 2, 8),
        //});
        //context.SaveChanges();

        var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
    }
}

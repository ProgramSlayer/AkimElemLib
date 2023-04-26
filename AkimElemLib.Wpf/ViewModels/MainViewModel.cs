using AkimElemLib.Wpf.ViewModels.CctvCams;
using AkimElemLib.Wpf.ViewModels.Intruders;
using AkimElemLib.Wpf.ViewModels.ISOs.Barriers;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.Buildings;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.SpecificAreas;
using System;

namespace AkimElemLib.Wpf.ViewModels;

public class MainViewModel : ViewModelBase
{
    public IntruderListingViewModel IntruderListingViewModel { get; }
    public SpecificAreaListingViewModel SpecificAreaListingViewModel { get; }
    public BuildingListingViewModel BuildingListingViewModel { get; }
    public AerialConstructionListingViewModel AerialConstructionListingViewModel { get; }
    public StationaryCctvCamListingViewModel StationaryCctvCamListingViewModel { get; }
    public BarrierListingViewModel BarrierListingViewModel { get; }

    public MainViewModel(
        IntruderListingViewModel intruderListingViewModel,
        SpecificAreaListingViewModel specificAreaListingViewModel,
        BuildingListingViewModel buildingListingViewModel,
        AerialConstructionListingViewModel aerialConstructionListingViewModel,
        StationaryCctvCamListingViewModel stationaryCctvCamListingViewModel,
        BarrierListingViewModel barrierListingViewModel)
    {
        ArgumentNullException.ThrowIfNull(intruderListingViewModel, nameof(intruderListingViewModel));
        ArgumentNullException.ThrowIfNull(specificAreaListingViewModel, nameof(specificAreaListingViewModel));
        ArgumentNullException.ThrowIfNull(buildingListingViewModel, nameof(buildingListingViewModel));
        ArgumentNullException.ThrowIfNull(aerialConstructionListingViewModel, nameof(aerialConstructionListingViewModel));
        ArgumentNullException.ThrowIfNull(stationaryCctvCamListingViewModel, nameof(stationaryCctvCamListingViewModel));
        ArgumentNullException.ThrowIfNull(barrierListingViewModel, nameof(barrierListingViewModel));

        IntruderListingViewModel = intruderListingViewModel;
        SpecificAreaListingViewModel = specificAreaListingViewModel;
        BuildingListingViewModel = buildingListingViewModel;
        AerialConstructionListingViewModel = aerialConstructionListingViewModel;
        StationaryCctvCamListingViewModel = stationaryCctvCamListingViewModel;
        BarrierListingViewModel = barrierListingViewModel;
    }
}
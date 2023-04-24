using AkimElemLib.Wpf.ViewModels.Intruders;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.Buildings;
using AkimElemLib.Wpf.ViewModels.SpecificObjects.SpecificAreas;
using System;

namespace AkimElemLib.Wpf.ViewModels;

public class MainViewModel : ViewModelBase
{
    public IntruderListingViewModel IntruderListingViewModel { get; }
    public SpecificAreaListingViewModel SpecificAreaListingViewModel { get; }
    public BuildingListingViewModel BuildingListingViewModel { get; }

    public MainViewModel(
        IntruderListingViewModel intruderListingViewModel,
        SpecificAreaListingViewModel specificAreaListingViewModel,
        BuildingListingViewModel buildingListingViewModel)
    {
        ArgumentNullException.ThrowIfNull(intruderListingViewModel, nameof(intruderListingViewModel));
        ArgumentNullException.ThrowIfNull(specificAreaListingViewModel, nameof(specificAreaListingViewModel));
        ArgumentNullException.ThrowIfNull(buildingListingViewModel, nameof(buildingListingViewModel));

        IntruderListingViewModel = intruderListingViewModel;
        SpecificAreaListingViewModel = specificAreaListingViewModel;
        BuildingListingViewModel = buildingListingViewModel;
    }
}
using AkimElemLib.Wpf.ViewModels;
using System.Windows;

namespace AkimElemLib.Wpf.Services.DialogWindowServices.Abstractions;

public interface IEditEntityDialogWindowService<TEditEntityViewModel, TEditEntityDialogWindow>
    where TEditEntityViewModel : ViewModelBase
    where TEditEntityDialogWindow : Window, new()
{
    public bool? ShowDialog(TEditEntityViewModel viewModel)
    {
        TEditEntityDialogWindow editEntityDialogWindow = new()
        {
            DataContext = viewModel,
            WindowStartupLocation = WindowStartupLocation.CenterScreen
        };
        bool? dialogResult = editEntityDialogWindow.ShowDialog();
        return dialogResult;
    }
}

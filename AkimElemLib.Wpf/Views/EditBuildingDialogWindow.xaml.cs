using System.Windows;

namespace AkimElemLib.Wpf.Views;

public partial class EditBuildingDialogWindow : Window
{
    public EditBuildingDialogWindow()
    {
        InitializeComponent();
    }

    private void BtnSubmit_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}

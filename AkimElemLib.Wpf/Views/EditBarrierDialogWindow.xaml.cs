using System.Windows;

namespace AkimElemLib.Wpf.Views;

public partial class EditBarrierDialogWindow : Window
{
    public EditBarrierDialogWindow()
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

using System;
using System.Windows;

namespace AkimElemLib.Wpf.Services.ExceptionHandlers;

public class MessageBoxExceptionHandler : IExceptionHandler
{
    public void Handle(Exception exception)
    {
        MessageBox.Show(exception.Message, exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
    }
}

using System;

namespace AkimElemLib.Wpf.Services.ExceptionHandlers;

public interface IExceptionHandler
{
    public void Handle(Exception exception);
}

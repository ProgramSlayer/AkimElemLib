using System;
using System.Threading.Tasks;

namespace AkimElemLib.Wpf.Commands;

public abstract class AsyncCommandBase : CommandBase
{
    private bool _isBusy;
    private readonly Action<Exception> _onException;

    protected AsyncCommandBase(Action<Exception> onException) => 
        _onException = onException ?? throw new ArgumentNullException(nameof(onException));
    
    public bool IsBusy
    {
        get => _isBusy; 
        set
        {
            _isBusy = value;
            OnCanExecuteChanged();
        }
    }
    
    public override bool CanExecute(object? parameter) => !IsBusy;
    
    public override async void Execute(object? parameter)
    {
        IsBusy = true;
        try
        {
            await ExecuteAsync(parameter);
        }
        catch (Exception e)
        {
            _onException.Invoke(e);
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    public abstract Task ExecuteAsync(object? parameter);
}

using System;
using System.Windows.Input;

namespace RagnarokOnlineItemViewer
{
    public class DelegateCommand : ICommand
    {
        readonly Action _targetExecuteMethod;
        readonly Func<bool> _targetCanExecuteMethod;

        public DelegateCommand( Action executeMethod )
        {
            _targetExecuteMethod = executeMethod;
        }

        public DelegateCommand( Action executeMethod, Func<bool> canExecuteMethod )
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged() => CanExecuteChanged( this, EventArgs.Empty );

        public bool CanExecute( object parameter )
        {
            if( _targetCanExecuteMethod != null )
            {
                return _targetCanExecuteMethod();
            }

            return _targetExecuteMethod != null;
        }

        public void Execute( object parameter ) => _targetExecuteMethod?.Invoke();
    }
}

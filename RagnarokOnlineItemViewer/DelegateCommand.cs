using System;
using System.Windows.Input;

namespace RagnarokOnlineItemViewer
{
    public class DelegateCommand<T> : ICommand
    {
        readonly Action<T> _targetExecuteMethod;
        readonly Func<T, bool> _targetCanExecuteMethod;

        public DelegateCommand( Action<T> executeMethod )
        {
            _targetExecuteMethod = executeMethod;
        }

        public DelegateCommand( Action<T> executeMethod, Func<T, bool> canExecuteMethod )
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
                return _targetCanExecuteMethod( (T)parameter );
            }

            return _targetExecuteMethod != null;
        }

        public void Execute( object parameter ) => _targetExecuteMethod?.Invoke( (T)parameter );
    }
}

using System.Windows.Input;

namespace Rumors.Desktop.Common
{
    public class RelayCommand : ICommand
    {
        private Func<bool> _canExecute;
        private Action _action;

        public RelayCommand(Action execute)
            : this(() => { return true; }, execute)
        {
        }

        public RelayCommand(Func<bool> canExecute, Action execute)
        {
            _canExecute = canExecute;
            _action = execute;
        }

        public event EventHandler? CanExecuteChanged = delegate { };

        public void RaiseExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute();
        }

        public void Execute(object? parameter)
        {
            _action();
        }
    }

    public class RelayCommand<T> : ICommand 
    {
        private Func<bool> _canExecute;
        private Action<T> _action;

        public RelayCommand(Action<T> execute)
            : this(() => { return true; }, execute)
        {
        }

        public RelayCommand(Func<bool> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _action = execute;
        }

        public event EventHandler? CanExecuteChanged = delegate { };

        public void RaiseExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute();
        }

        public void Execute(object? parameter)
        {
            if (parameter is T param) _action(param);
        }
    }
}

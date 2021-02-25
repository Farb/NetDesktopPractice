using System;
using System.Windows.Input;

namespace WpfMvvmDemo.Commands
{
    class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunction?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }

        public Action<object> ExecuteAction { get; set; }

        public Func<object, bool> CanExecuteFunction { get; set; }
    }
}

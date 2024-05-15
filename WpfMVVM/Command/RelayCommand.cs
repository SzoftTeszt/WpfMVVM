using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMVVM.Command
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object> execute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            this.execute(parameter);
        }
    }
}

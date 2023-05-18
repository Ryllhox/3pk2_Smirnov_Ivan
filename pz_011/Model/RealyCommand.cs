using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pz_011.Model
{
    internal class RelayCommand : ICommand
    {
        //  can execute
        private readonly Predicate<object>? _predicate;
        private readonly Action<object>? _execute;

        public event EventHandler? CanExecuteChanged
        {
            add
            {
                if (CanExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (CanExecute != null) CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand( Action<object> ex, Predicate<object> can)
        {
            _predicate = can;
            _execute = ex ?? throw new ArgumentNullException(nameof(ex));
        }

        public bool CanExecute(object? parameter)
        {
            return _predicate.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }

    }
}

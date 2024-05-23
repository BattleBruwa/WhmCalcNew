using System.Windows.Input;

namespace WhmCalcNew.Bases
{
    public class RelayCommand : ICommand
    {
        private Action<object> _Execute {  get; set; }

        private Predicate<object> _CanExecute {  get; set; }

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this._Execute = execute;
            this._CanExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExecute == null || _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}

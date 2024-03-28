using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WhmCalcNew.Models;
using WhmCalcNew.Views;

namespace WhmCalcNew.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TargetUnit>? _targets;
        public ObservableCollection<TargetUnit>? Targets
        {
            get { return _targets; }
            set
            {
                _targets = value;
                OnPropertyChanged();
            }
        }

        private AttackingUnit? _attackingUnit;
        public AttackingUnit? AttackingUnit
        {
            get { return _attackingUnit; }
            set
            {
                _attackingUnit = value;
                OnPropertyChanged();
            }
        }

        private OutputDataManager? _outputData;

        public OutputDataManager? OutputData
        {
            get { return _outputData; }
            set
            {
                _outputData = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Targets = TargetManager.GetTargets();
            AttackingUnit = new AttackingUnit();
            OutputData = new OutputDataManager();

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

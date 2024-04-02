using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WhmCalcNew.Engine.Calculations;
using WhmCalcNew.Models;

namespace WhmCalcNew.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private ObservableCollection<TargetUnit>? _targets;
        public ObservableCollection<TargetUnit>? Targets
        {
            get { return _targets; }
            set
            {
                _targets = value;
            }
        }

        private TargetUnit? _selectedTarget;
        public TargetUnit? SelectedTarget
        {
            get { return _selectedTarget; }
            set
            {
                _selectedTarget = value;
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
                OutputData?.Recalculate(AttackingUnit, SelectedTarget);
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


            //TESTING!!!!!!!! ПОТОМ УДАЛИТЬ!!!!!!!!!
            Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    i++;
                    Debug.WriteLine(i.ToString());
                    Debug.WriteLine($"Attacker: {AttackingUnit?.Attacks}, {AttackingUnit?.Accuracy}, {AttackingUnit?.Strength}, {AttackingUnit?.ArmorPen}, {AttackingUnit?.Damage}");
                    Debug.WriteLine($"Target: {SelectedTarget?.Thoughness}, {SelectedTarget?.Save}, {SelectedTarget?.Wounds}");
                    Debug.WriteLine($"Output: {OutputData?.HitsNum}, {OutputData?.WoundsNum}, {OutputData?.UnSavedNum}, {OutputData?.DeadModelsNum}, {OutputData?.TotalDamageNum}");
                    Thread.Sleep(1000);
                }
            });

        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using WhmCalcNew.Bases;
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
                Recalculate(AttackingUnit, SelectedTarget);
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

        private OutputData? _outputData;

        public OutputData? OutputData
        {
            get { return _outputData; }
            set
            {
                _outputData = value;
                OnPropertyChanged();
            }
        }

        // Комманды для контроля окна

        public ICommand HideWindowCommand { get; private set; }

        public ICommand CloseWindowCommand { get; private set; }

        public ICommand ChangeThemeCommand { get; private set; }
        

        public MainViewModel()
        {
            this.Targets = TargetManager.GetTargets();
            this.AttackingUnit = new AttackingUnit();
            this.AttackingUnit.PropertyChanged += AttackingUnit_PropertyChanged;
            this.OutputData = OutputDataManager.GetOutputData();

            // RelayCommand ставит CanExecute в null, если не передаем метод аргументом
            HideWindowCommand = new RelayCommand(HideWindow);

            CloseWindowCommand = new RelayCommand(CloseWindow);

            ChangeThemeCommand = new RelayCommand(ChangeTheme);


            //TESTING!!!!!!!! ПОТОМ УДАЛИТЬ!!!!!!!!!
            Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    i++;
                    Debug.WriteLine(i.ToString());
                    Debug.WriteLine($"Attacker1: {AttackingUnit?.Attacks}, {AttackingUnit?.Accuracy}, {AttackingUnit?.Strength}, {AttackingUnit?.ArmorPen}, {AttackingUnit?.Damage}");
                    Debug.WriteLine($"Attacker2: {AttackingUnit?.HasRerollToHit1}, {AttackingUnit?.HasRerollToHitAll}, {AttackingUnit?.HasRerollToWound1}, {AttackingUnit?.HasRerollToWoundAll}, {AttackingUnit?.HasLethalHits}, {AttackingUnit?.HasSustainedHits}, {AttackingUnit?.HasDevastatingWounds}, {AttackingUnit?.IsMinusOneToWound}, {AttackingUnit?.HasCritsOn5s}");
                    Debug.WriteLine($"Attacker3: {AttackingUnit?.LethalHitsNum}, {AttackingUnit?.SustainedHitsNum}, {AttackingUnit?.DevastatingWoundsNum}");
                    Debug.WriteLine($"Target: {SelectedTarget?.Toughness}, {SelectedTarget?.Save}, {SelectedTarget?.Wounds}");
                    Debug.WriteLine($"Output: {OutputData?.HitsNum}, {OutputData?.WoundsNum}, {OutputData?.UnSavedNum}, {OutputData?.DeadModelsNum}, {OutputData?.TotalDamageNum}");
                    Thread.Sleep(1000);
                }
            });

        }

        private void ChangeTheme(object obj)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this && item is IThemedWindow)
                {
                    (item as IThemedWindow).ChangeTheme();
                }
            }
        }

        private void CloseWindow(object obj)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    item.Close();
                }
            }
        }

        private void HideWindow(object obj)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    item.WindowState = WindowState.Minimized;
                }
            }
        }

        private void AttackingUnit_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Recalculate(AttackingUnit, SelectedTarget);
        }

        private void Recalculate(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker != null && target != null && this.OutputData != null)
            {
                OutputDataManager.SetHits(attacker);
                OutputDataManager.SetWounds(attacker, target);
                OutputDataManager.SetUnsavedWounds(attacker, target);
                OutputDataManager.SetDeadModels(attacker, target);
                OutputDataManager.SetTotalDamage(attacker, target);
            }
        }
    }
}

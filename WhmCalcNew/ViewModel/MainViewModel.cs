using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MvvmHelpers;
using WhmCalcNew.Bases;
using WhmCalcNew.Models;
using WhmCalcNew.Services;
using WhmCalcNew.Services.Calculations;

namespace WhmCalcNew.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ITargetsListService TargetsList { get; }
        public IModListService ModsList { get; }
        public ICalcOutputService Calc { get; }

        private TargetUnit? _selectedTarget;
        public TargetUnit? SelectedTarget
        {
            get { return _selectedTarget; }
            set
            {
                SetProperty(ref _selectedTarget, value);
                Recalculate(AttackingUnit, SelectedTarget, ModsList.PickedModificators);
            }
        }

        private AttackingUnit _attackingUnit;
        public AttackingUnit AttackingUnit
        {
            get { return _attackingUnit; }
            set
            {
                SetProperty(ref _attackingUnit, value);
            }
        }

        private OutputData _outputData;
        public OutputData OutputData
        {
            get { return _outputData; }
            set
            {
                _outputData = value;
            }
        }

        // Комманды для контроля окна

        public ICommand HideWindowCommand { get; private set; }

        public ICommand CloseWindowCommand { get; private set; }

        public ICommand ChangeThemeCommand { get; private set; }

        

        public MainViewModel(ITargetsListService targetsList, IModListService modsList, ICalcOutputService calc)
        {
            TargetsList = targetsList;
            ModsList = modsList;
            Calc = calc;
            OutputData = new OutputData();
            AttackingUnit = new AttackingUnit();
            AttackingUnit.PropertyChanged += AttackingUnit_PropertyChanged;

            // RelayCommand ставит CanExecute в null, если не передаем метод аргументом
            HideWindowCommand = new RelayCommand(HideWindow);

            CloseWindowCommand = new RelayCommand(CloseWindow);

            ChangeThemeCommand = new RelayCommand(ChangeTheme);
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
            Recalculate(AttackingUnit, SelectedTarget, ModsList.PickedModificators);
        }

        private void Recalculate(AttackingUnit attacker, TargetUnit? target, ObservableCollection<Modificator> mods)
        {
            if (attacker != null && target != null && OutputData != null)
            {
                OutputData.AttacksNum = Calc.TotalAttacks(attacker);
                OutputData.HitsNum = Calc.TotalHits(attacker, mods);
                OutputData.WoundsNum = Calc.TotalWounds(attacker, target, mods);
                OutputData.UnSavedNum = Calc.TotalUnSaved(attacker, target, mods);
                OutputData.DeadModelsNum = Calc.TotalDeadModels(attacker, target, mods);
                OutputData.TotalDamageNum = Calc.TotalDamage(attacker, target, mods);
            }
        }
    }
}

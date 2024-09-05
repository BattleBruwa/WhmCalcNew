using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers;
using WhmCalcNew.Bases;
using WhmCalcNew.Models;
using WhmCalcNew.Services;
using WhmCalcNew.Services.Calculations;
using WhmCalcNew.Services.DataAccess;
using WhmCalcNew.Views;

namespace WhmCalcNew.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        #region Свойства, сервисы
        public IModListService ModsList { get; }
        public ICalcOutputService Calc { get; }

        public ObservableCollection<TargetUnit> TargetsList { get; set; }

        public ObservableCollection<Modificator> PickedMods { get; set; } = new();

        private TargetUnit? _selectedTarget;
        public TargetUnit? SelectedTarget
        {
            get { return _selectedTarget; }
            set
            {
                SetProperty(ref _selectedTarget, value);
                Recalculate(AttackingUnit, SelectedTarget, PickedMods);
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
        #endregion
        #region Конструкторы
        public MainViewModel(IModListService modsList, ICalcOutputService calc)
        {
            ModsList = modsList;
            Calc = calc;
            OutputData = new OutputData();
            AttackingUnit = new AttackingUnit();
            AttackingUnit.PropertyChanged += AttackingUnit_PropertyChanged;
        }
        #endregion
        #region Комманды
        [RelayCommand]
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
        [RelayCommand]
        private void CloseWindow(object obj)
        {
            foreach (Window item in Application.Current.Windows)
            {
                //if (item.DataContext == this)
                //{
                //    item.Close();
                //}
                item.Close();
            }
        }
        [RelayCommand]
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
        [RelayCommand]
        public void ShowAddTarget(object obj)
        {
            AddTargetWindow addTargetWindow = App.AppHost.Services.GetService<AddTargetWindow>();
            addTargetWindow.Show();
        }

        #endregion
        #region Вспомогательные методы
        // Загрузка коллекции целей
        public async Task FillTargetsCollectionAsync(IWhmDbService dbService)
        {
            TargetsList = new(await dbService.GetTargetsAsync());
        }

        private void AttackingUnit_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Recalculate(AttackingUnit, SelectedTarget, PickedMods);
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
        #endregion
    }
}

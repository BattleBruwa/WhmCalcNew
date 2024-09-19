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


        private TargetUnit? _selectedTarget;
        public TargetUnit? SelectedTarget
        {
            get { return _selectedTarget; }
            set
            {
                SetProperty(ref _selectedTarget, value);
                Recalculate(AttackingUnit, SelectedTarget, OutputData, ModsList.PickedMods);
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
            ModsList.PickedMods.CollectionChanged += PickedMods_CollectionChanged;
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
        // Комманда для обработки чекбоксов модификаторов
        [RelayCommand]
        public void PickMod(object obj)
        {
            var parameters = (object[])obj;
            bool check = (bool)parameters[0];
            Modificator pickedMod = (Modificator)parameters[1];
            if (check)
            {
                ModsList.PickedMods.Add(pickedMod);
            }
            else
            {
                ModsList.PickedMods.Remove(pickedMod);
            }
        }
        #endregion
        #region Вспомогательные методы
        // Загрузка коллекции целей
        public async Task FillTargetsCollectionAsync(IWhmDbService dbService)
        {
            TargetsList = new(await dbService.GetTargetsAsync());
        }
        // ------------------------
        private void AttackingUnit_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Recalculate(AttackingUnit, SelectedTarget, OutputData, ModsList.PickedMods);
        }

        private void PickedMods_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Recalculate(AttackingUnit, SelectedTarget, OutputData, ModsList.PickedMods);
        }

        private void Recalculate(AttackingUnit attacker, TargetUnit? target, OutputData output, ObservableCollection<Modificator> mods)
        {
            if (attacker != null && target != null && output != null)
            {
                Calc.CalculateOutput(attacker, target, output, mods);
            }
        }
        #endregion
    }
}

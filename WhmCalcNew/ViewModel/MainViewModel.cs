using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers;
using WhmCalcNew.Engine.ThemeChanger;
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

        private bool isDarkThemed = true;

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
        // Смена цели
        [RelayCommand]
        private void ChangeTheme(object obj)
        {
            ThemeChanger.ChangeTheme(ref isDarkThemed);
        }
        // Закрыть окно
        [RelayCommand]
        private void CloseWindow(object obj)
        {
            foreach (Window item in Application.Current.Windows)
            {
                item.Close();
            }
        }
        // Свернуть окно
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
        // Добавление цели
        [RelayCommand]
        private void ShowAddTarget(object obj)
        {
            AddTargetWindow? addTargetWindow = App.AppHost.Services.GetService<AddTargetWindow>();
            if (addTargetWindow != null)
            {
                addTargetWindow.Owner = App.AppHost.Services.GetService<MainWindow>();
                addTargetWindow.ShowDialog();
            }
        }
        // Комманда для обработки чекбоксов модификаторов
        [RelayCommand]
        private void PickMod(object obj)
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
        [RelayCommand]
        private void DeleteSelectedTarget()
        {

        }
        // Сброс ввода
        [RelayCommand]
        private void ResetInput()
        {
            AttackingUnit.Attacks = "0";
            AttackingUnit.Accuracy = 0;
            AttackingUnit.Strength = 0;
            AttackingUnit.ArmorPen = 0;
            AttackingUnit.Damage = "0";
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

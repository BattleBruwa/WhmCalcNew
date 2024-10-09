using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
        public IWhmDbService DbService { get; }

        public ObservableCollection<TargetUnit> TargetsList { get; set; }

        private TargetUnit? _selectedTarget;
        public TargetUnit? SelectedTarget
        {
            get { return _selectedTarget; }
            set
            {
                SetProperty(ref _selectedTarget, value);
                DeleteSelectedTargetCommand.NotifyCanExecuteChanged();
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
        public MainViewModel(IModListService modsList, ICalcOutputService calc, IWhmDbService dbService)
        {
            ModsList = modsList;
            Calc = calc;
            DbService = dbService;
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
        // Комманда для удаления таргета из бд
        [RelayCommand(CanExecute = nameof(CanDeleteTarget))]
        private async Task DeleteSelectedTarget()
        {
            TargetUnit? targetToDeleteTL = null;

            try
            {
            targetToDeleteTL = TargetsList.Single(t => t.UnitName == SelectedTarget.UnitName);
            }
            catch (ArgumentNullException ex)
            {
                var Message = new MessageWindow($"Failed to delete target.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                Message.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                var Message = new MessageWindow($"Failed to delete target.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                Message.ShowDialog();
            }
            catch (Exception ex)
            {
                var Message = new MessageWindow($"Failed to delete target.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                Message.ShowDialog();
            }
            if (targetToDeleteTL != null)
            {
                var targetToDeleteDB = await DbService.GetTargetByName(SelectedTarget.UnitName);
                if (targetToDeleteDB != null)
                {
                    var ConfirmMessage = new MessageWindow("Are you sure, you want to delete this target?", MessageType.Confirmation);
                    ConfirmMessage.Owner = App.AppHost.Services.GetService<MainWindow>();
                    bool? confirmResult = ConfirmMessage.ShowDialog();
                    if (confirmResult.Value)
                    {
                        await DbService.DeleteTargetAsync(targetToDeleteDB);
                        if (TargetsList.Remove(targetToDeleteTL))
                        {
                            Debug.WriteLine("Target deleted");
                            var SuccessMessage = new MessageWindow("The target has been deleted from DataBase", MessageType.Success);
                            SuccessMessage.Owner = App.AppHost.Services.GetService<MainWindow>();
                            bool? result = SuccessMessage.ShowDialog();
                        }
                    }
                }
            }
        }

        // Сброс ввода
        [RelayCommand]
        private void ResetInput()
        {
            AttackingUnit.ResetState();
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
        // Пересчет вывода
        private void Recalculate(AttackingUnit attacker, TargetUnit? target, OutputData output, ObservableCollection<Modificator> mods)
        {
            if (attacker != null && target != null && output != null)
            {
                Calc.CalculateOutput(attacker, target, output, mods);
            }
        }
        // --------------
        // Проверка условия для комманды удаления цели
        private bool CanDeleteTarget()
        {
            if (SelectedTarget != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // ------------------------------------------
        #endregion
    }
}

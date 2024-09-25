using System.Diagnostics;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WhmCalcNew.Models;
using WhmCalcNew.Services.DataAccess;

namespace WhmCalcNew.ViewModel
{
    public partial class AddTargetViewModel: ObservableObject
    {
        [ObservableProperty]
        private TargetUnit newTarget;

        public IWhmDbService DbService { get; }

        private readonly MainViewModel mainViewModel;

        [ObservableProperty]
        private bool canExecuteAddTarget = false;

        public AddTargetViewModel(IWhmDbService dbService, MainViewModel mainViewModel)
        {
            DbService = dbService;
            this.mainViewModel = mainViewModel;
            NewTarget = new TargetUnit();
            NewTarget.PropertyChanged += NewTarget_PropertyChanged;
        }

        private void NewTarget_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NewTarget.UnitName))
            {
                if (string.IsNullOrWhiteSpace(NewTarget.UnitName))
                {
                    CanExecuteAddTarget = false;
                }
                else
                {
                    CanExecuteAddTarget = true;
                }
            }
        }

        // Реализация через [NotifyCanExecuteChangedFor] не работает, возможно из-за async Task,
        // по-этому включение кнопки реализавано в лоб через привязку свойства к ивенту
        // (обработчик - NewTarget_PropertyChanged)
        [RelayCommand/*(CanExecute = nameof(CanAddTarget))*/]
        private async Task AddTarget()
        {
            // TODO: Оформить новое окно с подтверждением, если цель с таким именем уже существует
            if (await DbService.GetTargetByName(NewTarget.UnitName) == null)
            {
                await DbService.AddTargetAsync(NewTarget);
                mainViewModel.TargetsList.Add(NewTarget);
            }
            await DbService.UpdateTargetAsync(NewTarget);
        }

        [RelayCommand]
        private void CloseWindow(object obj)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    item.DialogResult = false;
                }
            }
        }
    }
}

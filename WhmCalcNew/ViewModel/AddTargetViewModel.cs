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
        [NotifyCanExecuteChangedFor(nameof(AddTargetCommand))]
        private TargetUnit newTarget;


        public IWhmDbService DbService { get; }

        private MainViewModel mainViewModel;

        public AddTargetViewModel(IWhmDbService dbService, MainViewModel mainViewModel)
        {
            DbService = dbService;
            this.mainViewModel = mainViewModel;
            NewTarget = new TargetUnit();
            // Тест
            Task test = new Task(TestWriting);
            test.Start();
        }


        [RelayCommand(CanExecute = nameof(CanAddTarget))]
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
        private bool CanAddTarget()
        {
            if (String.IsNullOrEmpty(NewTarget.UnitName))
            {
                return false;
            }
            else
                return true;
        }

        [RelayCommand]
        private void CloseWindow(object obj)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    item.Hide();
                }
            }
        }
        
        // Тест
        private void TestWriting()
        {
            while (true)
            {
                Debug.WriteLine($"NT: {NewTarget.ToString()} where name : {NewTarget.UnitName}");
                Thread.Sleep(1000);
            }
        }
    }
}

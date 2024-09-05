using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using WhmCalcNew.Models;
using WhmCalcNew.Services.DataAccess;

namespace WhmCalcNew.ViewModel
{
    public partial class AddTargetViewModel
    {
        public TargetUnit NewTarget { get; set; } = new();
        public IWhmDbService DbService { get; }

        private MainViewModel mainViewModel;

        public AddTargetViewModel(IWhmDbService dbService, MainViewModel mainViewModel)
        {
            DbService = dbService;
            this.mainViewModel = mainViewModel;
        }
        [RelayCommand]
        public async Task AddTarget()
        {
            if (String.IsNullOrEmpty(NewTarget.UnitName))
            {
                return;
            }
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
                    item.Hide();
                }
            }
        }
    }
}

using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WhmCalcNew.Models;
using WhmCalcNew.Services.DataAccess;
using WhmCalcNew.Views;

namespace WhmCalcNew.ViewModel
{
    public partial class AddTargetViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddTargetCommand))]
        private TargetUnit newTarget;

        public IWhmDbService DbService { get; }

        private readonly MainViewModel mainViewModel;

        public AddTargetViewModel(IWhmDbService dbService, MainViewModel mainViewModel)
        {
            DbService = dbService;
            this.mainViewModel = mainViewModel;
            NewTarget = new TargetUnit();
        }

        
        [RelayCommand(CanExecute = nameof(CanAddTarget))]
        private async Task AddTarget()
        {
            if (await DbService.GetTargetByName(NewTarget.UnitName) == null)
            {
                await DbService.AddTargetAsync(NewTarget);
                mainViewModel.TargetsList.Add(NewTarget);
                Debug.WriteLine("Target added");
                var SuccessMessage = new MessageWindow("The target has been added to DataBase", MessageType.Success);
                SuccessMessage.Owner = GetAssociatedWindow();
                bool? result = SuccessMessage.ShowDialog();
            }
            else
            {
                var ConfirmMessage = new MessageWindow("Target with this name already exists, do you wish to update this target?", MessageType.Confirmation);
                ConfirmMessage.Owner = GetAssociatedWindow();
                bool? confirmResult = ConfirmMessage.ShowDialog();
                if (confirmResult.Value)
                {
                    await DbService.UpdateTargetAsync(NewTarget);
                    Debug.WriteLine("Target updated");
                    var SuccessMessage = new MessageWindow("The target has been updated", MessageType.Success);
                    SuccessMessage.Owner = GetAssociatedWindow();
                    bool? result = SuccessMessage.ShowDialog();
                }
            }
        }
        private bool CanAddTarget()
        {
            if (IsValid(GetAssociatedWindow()))
            {
                return true;
            }
            else
            { return false; }
        }

        public bool IsValid(DependencyObject obj)
        {
            return !Validation.GetHasError(obj) && LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>().All(IsValid);
        }

        private Window? GetAssociatedWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item is AddTargetWindow && item.DataContext == this)
                {
                    return item;
                }
            }
            return null;
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

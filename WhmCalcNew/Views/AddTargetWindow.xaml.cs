using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WhmCalcNew.ViewModel;

namespace WhmCalcNew.Views
{
    public partial class AddTargetWindow : Window
    {
        AddTargetViewModel viewModel;
        public AddTargetWindow(AddTargetViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
        }

        private void closeWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private async void EditableTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox != null)
            {
                await Application.Current.Dispatcher.InvokeAsync(textBox.SelectAll, DispatcherPriority.Background);
            }
        }
    }
}

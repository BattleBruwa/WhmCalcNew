using System.Windows;
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
            this.DialogResult = false;
            Close();
        }
    }
}

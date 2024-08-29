using System.Windows;
using WhmCalcNew.Bases;
using WhmCalcNew.Engine.ThemeChanger;
using WhmCalcNew.Services;
using WhmCalcNew.ViewModel;

namespace WhmCalcNew.Views
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class MainWindow : Window, IThemedWindow
    {
        private bool _isDarkThemed = true;


        MainViewModel viewModel;
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.DataContext = this.viewModel;
            TestDataGrid.ItemsSource = ModListService.ModificatorsList;
        }


        public void ChangeTheme()
        {
            ThemeChanger.ChangeTheme(ref _isDarkThemed);
        }
    }
}

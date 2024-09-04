using System.Windows;
using WhmCalcNew.Bases;
using WhmCalcNew.Engine.ThemeChanger;
using WhmCalcNew.Models;
using WhmCalcNew.Services;
using WhmCalcNew.Services.DataAccess;
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
            DataContext = this.viewModel;
            TestDataGrid.ItemsSource = ModListService.ModificatorsList;
        }

        public async Task FillCollection(IWhmDbService dbService)
        {
            viewModel.TargetsList = new(await dbService.GetTargetsAsync());
        }

        public void ChangeTheme()
        {
            ThemeChanger.ChangeTheme(ref _isDarkThemed);
        }
    }
}

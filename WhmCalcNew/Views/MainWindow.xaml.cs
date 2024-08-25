using System.Windows;
using WhmCalcNew.Bases;
using WhmCalcNew.Engine.ThemeChanger;
using WhmCalcNew.ViewModel;

namespace WhmCalcNew.Views
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class MainWindow : Window, IThemedWindow
    {
        private bool _isDarkThemed = true;


        MainViewModel mainViewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            
            this.DataContext = mainViewModel;

        }


        public void ChangeTheme()
        {
            ThemeChanger.ChangeTheme(ref _isDarkThemed);
        }
    }
}

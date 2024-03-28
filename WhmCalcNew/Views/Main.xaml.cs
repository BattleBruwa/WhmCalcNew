using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WhmCalcNew.Engine;
using WhmCalcNew.Models;
using WhmCalcNew.ViewModel;

namespace WhmCalcNew.Views
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        MainViewModel mainViewModel = new MainViewModel();
        public Main()
        {
            InitializeComponent();
            
            this.DataContext = mainViewModel;
        }

        private void AttacksBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainViewModel.OutputData.Recalculate(mainViewModel.AttackingUnit, TargetChoiceBox.SelectedItem as TargetUnit);
        }
    }
}

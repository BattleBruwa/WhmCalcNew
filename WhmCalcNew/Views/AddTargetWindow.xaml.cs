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
using WhmCalcNew.ViewModel;

namespace WhmCalcNew.Views
{
    /// <summary>
    /// Логика взаимодействия для AddTargetWindow.xaml
    /// </summary>
    public partial class AddTargetWindow : Window
    {
        AddTargetViewModel viewModel;
        public AddTargetWindow(AddTargetViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
        }
    }
}

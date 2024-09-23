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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WhmCalcNew.Views.Components
{
    /// <summary>
    /// Логика взаимодействия для AddTargetComponent.xaml
    /// </summary>
    public partial class AddTargetComponent : UserControl
    {
        public AddTargetComponent()
        {
            InitializeComponent();
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

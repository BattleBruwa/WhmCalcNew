using System.Windows;
using System.Windows.Controls;

namespace WhmCalcNew.Views.Components
{
    /// <summary>
    /// Логика взаимодействия для ModificatorsPartComponent.xaml
    /// </summary>
    public partial class ModificatorsPartComponent : UserControl
    {
        public ModificatorsPartComponent()
        {
            InitializeComponent();
        }
        #region Obsolete
        //private void CheckBoxR1_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBoxR1.IsChecked = true;
        //    CheckBoxR1.Command.Execute(CheckBoxR1.CommandParameter);
        //    CheckBoxRH.IsChecked = false;
        //    CheckBoxRH.Command.Execute(CheckBoxRH.CommandParameter);
        //}

        //private void CheckBoxRH_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBoxRH.IsChecked = true;
        //    CheckBoxRH.Command.Execute(CheckBoxRH.CommandParameter);
        //    CheckBoxR1.IsChecked = false;
        //    CheckBoxR1.Command.Execute(CheckBoxR1.CommandParameter);
        //}

        //private void CheckBoxR1W_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBoxR1W.IsChecked = true;
        //    CheckBoxR1W.Command.Execute(CheckBoxR1W.CommandParameter);
        //    CheckBoxRW.IsChecked = false;
        //    CheckBoxRW.Command.Execute(CheckBoxRW.CommandParameter);
        //}

        //private void CheckBoxRW_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBoxRW.IsChecked = true;
        //    CheckBoxRW.Command.Execute(CheckBoxRW.CommandParameter);
        //    CheckBoxR1W.IsChecked = false;
        //    CheckBoxR1W.Command.Execute(CheckBoxR1W.CommandParameter);
        //}
        #endregion

        // 1 обработчик вместо 4
        private void ReRollsCB_Checked(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                CheckBox senderChB = (CheckBox)sender;

                senderChB.IsChecked = true;
                senderChB.Command.Execute(senderChB.CommandParameter);
                switch (senderChB.Name)
                {
                    case "CheckBoxR1":
                        CheckBoxRH.IsChecked = false;
                        CheckBoxRH.Command.Execute(CheckBoxRH.CommandParameter);
                        break;
                    case "CheckBoxRH":
                        CheckBoxR1.IsChecked = false;
                        CheckBoxR1.Command.Execute(CheckBoxR1.CommandParameter);
                        break;
                    case "CheckBoxR1W":
                        CheckBoxRW.IsChecked = false;
                        CheckBoxRW.Command.Execute(CheckBoxRW.CommandParameter);
                        break;
                    case "CheckBoxRW":
                        CheckBoxR1W.IsChecked = false;
                        CheckBoxR1W.Command.Execute(CheckBoxR1W.CommandParameter);
                        break;
                }
            }
        }
    }
}

using System.Windows;

namespace WhmCalcNew.Views
{
    public partial class MessageWindow : Window
    {

        public MessageWindow(string text, MessageType type)
        {
            InitializeComponent();
            messageText.Text = text;

            switch (type)
            {
                case MessageType.Confirmation:
                    messageHeader.Text = "Confirmation";
                    twoButtonPanel.Visibility = Visibility.Visible;
                    oneButtonPanel.Visibility = Visibility.Collapsed;
                    break;
                case MessageType.Success:
                    messageHeader.Text = "Success";
                    twoButtonPanel.Visibility = Visibility.Collapsed;
                    oneButtonPanel.Visibility = Visibility.Visible;
                    break;
                case MessageType.Error:
                    messageHeader.Text = "Error";
                    this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    twoButtonPanel.Visibility = Visibility.Collapsed;
                    oneButtonPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void leftBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void rightBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void oneBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void closeWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }

    public enum MessageType
    {
        Confirmation,
        Success,
        Error,
    }
}

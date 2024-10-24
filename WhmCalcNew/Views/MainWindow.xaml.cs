﻿using System.Windows;
using WhmCalcNew.ViewModel;

namespace WhmCalcNew.Views
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
        }

        // Сброс ввода
        private void ResetAttacker(object sender, RoutedEventArgs e)
        {
            AttackerComponent.AttacksTB.Text = "0";
            AttackerComponent.AccuracyTB.Text = "0";
            AttackerComponent.StrengthTB.Text = "0";
            AttackerComponent.ArmorPenTB.Text = "0";
            AttackerComponent.DamageTB.Text = "0";
        }
    }
}

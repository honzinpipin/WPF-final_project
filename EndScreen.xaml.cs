using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace _2A_projekt_WPF
{
    /// <summary>
    /// Interaction logic for EndScreen.xaml
    /// </summary>
    public partial class EndScreen : Window
    {
        public EndScreen(bool IsWinner)
        {
            InitializeComponent();

            if (IsWinner)
            {
                EndLabel.Foreground = Brushes.Green;
                EndLabel.Content = "YOU WON";
            }
            else
            {
                EndLabel.Foreground = Brushes.Red;
                EndLabel.Content = "YOU LOST";
            }
        }


        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void PlayAgainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Game = new MainWindow();
            GameEnd.Close();
            Game.Show();
        }
    }
}

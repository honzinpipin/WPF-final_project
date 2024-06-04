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

namespace _2A_projekt_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DifficultyEasy(object sender, RoutedEventArgs e)
        {
            Game game = new Game(10, Board, Result, EndTitle, EndScreen, CenterButton, GameWindow);
            SetupGame();
        }

        private void DifficultyIntermediate(object sender, RoutedEventArgs e)
        {
            Game game = new Game(7, Board, Result, EndTitle, EndScreen, CenterButton, GameWindow);
            SetupGame();
        }

        private void DifficultyHard(object sender, RoutedEventArgs e)
        {
            Game game = new Game(5, Board, Result, EndTitle, EndScreen, CenterButton, GameWindow);
            SetupGame();
        }

        private void SetupGame()
        {
            Game.CreateGrid();
            Game.CreateResultSquares();

            Setup.Visibility = Visibility.Collapsed;
            Board.Visibility = Visibility.Visible;
            CenterButton.Visibility = Visibility.Visible;
            Result.Visibility = Visibility.Visible;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
           
            Game.Check();
            
        }


        
        
    }
}

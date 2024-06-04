    using _2A_projekt_WPF;
using Accessibility;
using System;
    using System.Collections.Generic;
    using System.Data.Common;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
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
    using static System.Net.Mime.MediaTypeNames;

    namespace _2A_projekt_WPF
    {
    internal class Game
    {
        private static int _columns = 4;
        private static int _rows;
        private static Grid _board;
        private static Grid _results;
        private static int _tries;
        private static Label _endLabel;
        private static bool _isWinner = false;
        private static Grid _endScreen;
        private static Grid _centerButton;
        private static Window _gameWindow;

        public HiddenCode hiddenCode = new HiddenCode();

        public Game(int Rows, Grid Board, Grid Result, Label EndLabel, Grid EndScreen, Grid CenterButton, Window GameWindow)
        {
            _rows = Rows;
            _board = Board;
            _results = Result;
            _endLabel = EndLabel;
            _endScreen = EndScreen;
            _centerButton = CenterButton;
            _gameWindow = GameWindow;
        }

        public static int[] GuessedCode = new int[4];   

        // Připravit grid
        public static void CreateGrid()
        {
            for (int i = 0; i < _rows; i++)
            {
                _board.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < _columns; i++)
            {
                _board.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _columns; x++)
                {
                    Box box = new Box();
                    Grid.SetColumn(box, x);
                    Grid.SetRow(box, y);
                    box.Width = 100;
                    box.Height = 100;
                    box.MouseLeftButtonDown += Box_MouseButtonDown;
                    
                    _board.Children.Add(box);
                }
            }
        }


        public static void CreateResultSquares()
        {
            for (int i = 0; i < _rows; i++)
            {
                _results.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < _columns; i++)
            {
                _results.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _columns; x++)
                {
                    System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle
                    {
                        Width = 100,
                        Height = 95,
                        Fill = new BrushConverter().ConvertFromString("#FF312F2F") as Brush,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        Margin = new Thickness(3)

                    };
                    Grid.SetColumn(rect, x);
                    Grid.SetRow(rect, y);
                    rect.HorizontalAlignment = HorizontalAlignment.Right;
                    
                    _results.Children.Add(rect);
                }
            }
        }



        private static void Box_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            Box clickedBox = (Box)sender;
            int clickedYIndex = Grid.GetRow(clickedBox);
            if (clickedYIndex != Box.YIndex)
            {

            }
            else
            {
                clickedBox.AddIndex();
                clickedBox.ChangeColor();
            }
        }

        public static void Check()
        {
            


            _tries++;
            for (int i = 0; i < _columns; i++)
            {
                foreach (UIElement element in _board.Children)
                {
                    if (element is Box box && Grid.GetRow(box) == Box.YIndex && Grid.GetColumn(box) == i)
                    {
                        GuessedCode[i] = box.ColorIndex;
                        break; 
                    }
                }
            }

            if (CheckIfFilled())
            {
                int CorrectColorAndPlace = 0;
                int CorrectColorWrongPlace = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (GuessedCode[i] == HiddenCode.GetHiddenCode()[i])
                    {
                        CorrectColorAndPlace++;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (HiddenCode.GetHiddenCode().Contains(GuessedCode[i]) && HiddenCode.GetHiddenCode()[i] != GuessedCode[i])
                    {
                        CorrectColorWrongPlace++;
                    }
                }
                if (CorrectColorAndPlace == 4)
                {
                    _isWinner = true;
                    EndScreenShow(_isWinner);
                }
                else if (_tries == _rows)
                {
                    EndScreenShow(_isWinner);
                }
                else
                {
                    ChangeResultColors(CorrectColorAndPlace, CorrectColorWrongPlace);

                }
                Box.YIndex++;
            }
            else
            {
                _tries--;
            }

          
        }

        public static bool CheckIfFilled()
        {
            if (GuessedCode.Contains(-1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void ChangeResultColors(int correctColorAndPlace, int correctColorWrongPlace)
        {

            int Y = Box.YIndex;
            for (int i = 0; i < _columns; i++)
            {
                int X = i;
                foreach (UIElement element in _results.Children)
                {
                   
                    if (element is System.Windows.Shapes.Rectangle rect)
                    {
                        int pluh = Grid.GetRow(rect);
                        int buh = Grid.GetColumn(rect);
                        if (Y == Grid.GetRow(rect) && X == Grid.GetColumn(rect))
                        {
                            
                            if (correctColorAndPlace > 0)
                            {
                                correctColorAndPlace--;
                                rect.Fill = Brushes.Green;
                            }
                            else if (correctColorWrongPlace > 0)
                            {
                                correctColorWrongPlace--;
                                rect.Fill = Brushes.Orange;
                            }
                            else
                            {

                            }
                        }
                        
                        

                    }
                }
            }

            

        }

        public static void EndScreenShow(bool isWinner)
        {
            EndScreen EndScr = new EndScreen(isWinner);
            EndScr.Show();
            _gameWindow.Close();

        }


    }
}





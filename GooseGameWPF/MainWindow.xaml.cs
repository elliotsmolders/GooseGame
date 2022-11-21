using GooseGameWPF.Entities;
using GooseGameWPF.ViewModels;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GooseGameWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm = new MainViewModel();



        public MainWindow()
        {
            InitializeComponent();
            GooseGrid.DataContext = vm;
            vm.Init();
            StylelizeGridTiles();
            SetplayerNames();

        }

        //buh
        private void SetplayerNames() {

            PlayerLabel1.Content = vm.GetPlayerName(0);
            PlayerLabel2.Content = vm.GetPlayerName(1);
            PlayerLabel3.Content = vm.GetPlayerName(2);
            PlayerLabel4.Content = vm.GetPlayerName(3);
         }




        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            updateCurrentPlayerPosition();
            vm.SetNextPlayer();
            int roll1 = vm.RollDice();
            int roll2 = vm.RollDice();
            int currentRoll = roll1 + roll2;
            Roll1.Content = roll1;
            Roll2.Content = roll2;
            CurrentRoll.Content = currentRoll;
            string currentTile = vm.GetCurrentPlayerTile();
            vm.PlayTurn(roll1, roll2);
            //Debug.Content = vm.GetCurrentPlayerPositions();
            CurrentPlayerTile.Content= currentTile;
            updateCurrentPlayerPosition();
        }


        private Label[] generatedLabels = new Label[64];
        private System.Windows.Point[] generatedPoints = new System.Windows.Point[64];

        private int[,] StylelizeGridTiles()

        {
            int[,] tileGrid = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Label tileLabel = new();
                    Border b = new();

                    b.BorderThickness = new Thickness(10);
                    tileLabel.HorizontalAlignment = HorizontalAlignment.Center;
                    tileLabel.VerticalAlignment = VerticalAlignment.Center;

                    if (i % 2 == 0)
                    {
                        int evenTiles = 63 - (i * 8 + j);
                        tileLabel.Name = $"Tile{evenTiles}";
                        tileLabel.Content = $"Tile{evenTiles}";
                        generatedLabels[evenTiles] = (tileLabel);
                        generatedPoints[evenTiles] = new System.Windows.Point(i, j);
                    }
                    else
                    {
                        int oddTiles = 63 - (i * 8 + 7 - j);
                        tileLabel.Name = $"Tile{oddTiles}";
                        tileLabel.Content = $"Tile{oddTiles}";
                        generatedLabels[oddTiles] = (tileLabel);
                        generatedPoints[oddTiles] = new System.Windows.Point(i, j);
                    }

                    foreach (int pos in tileGrid)
                    {
                        if ((j + i) % 2 == 0)
                        {
                            b.BorderBrush = new SolidColorBrush(Colors.Blue);
                            tileLabel.Background = Brushes.Beige;
                        }
                        else
                        {
                            b.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                    }
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(tileLabel, i);
                    Grid.SetColumn(tileLabel, j);

                    GooseGrid.Children.Add(tileLabel);
                    GooseGrid.Children.Add(b);
                }
            }
            return tileGrid;
        }

        //TODO Beetje uit elkaar halen
        private void updateCurrentPlayerPosition()
        {

            
            int currentPos = vm.GetCurrentPlayerPosition();
            int playerposX = (int)generatedPoints[currentPos].X;
            int playerposY = (int)generatedPoints[currentPos].Y;
            RectPlayer1.SetValue(Grid.RowProperty, playerposX);
            RectPlayer1.SetValue(Grid.ColumnProperty, playerposY);
        }

    }
}
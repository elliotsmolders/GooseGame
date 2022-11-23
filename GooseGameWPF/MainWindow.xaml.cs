using GooseGameWPF.ViewModels;
using System;
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
            SpiralBoard();
        }

        //buh
        private void DisplayPlayerInfo()
        {
            string playerNamePos1 = vm.GetPlayerName(0) + " is on tile " + vm.GetPlayerPosition(0);
            string playerNamePos2 = vm.GetPlayerName(1) + " is on tile " + vm.GetPlayerPosition(1);
            string playerNamePos3 = vm.GetPlayerName(2) + " is on tile " + vm.GetPlayerPosition(2);
            string playerNamePos4 = vm.GetPlayerName(3) + " is on tile " + vm.GetPlayerPosition(3);
            PlayerLabel1.Content = playerNamePos1;
            PlayerLabel2.Content = playerNamePos2;
            PlayerLabel3.Content = playerNamePos3;
            PlayerLabel4.Content = playerNamePos4;
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
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
            CurrentPlayerTile.Content = currentTile;
            vm.UpdateTurnLog();
            updatePlayerPositions();
            DisplayPlayerInfo();
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool isWinner = vm.CheckForWinner();

            if (isWinner)
            {
                string winnerName = vm.GetWinnerName();
                MessageBox.Show($"{winnerName} has wonnered!");
                GooseGrid.IsEnabled = false;
            }
        }

        private Label[] generatedLabels = new Label[64];
        private System.Windows.Point[] generatedPoints = new System.Windows.Point[64];

        private void BoustrophedonBoard()

        {
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
                        b.BorderBrush = new SolidColorBrush(Colors.Blue);
                        tileLabel.Background = Brushes.Beige;
                        generatedLabels[evenTiles] = (tileLabel);
                        generatedPoints[evenTiles] = new System.Windows.Point(i, j);
                    }
                    else
                    {
                        int oddTiles = 63 - (i * 8 + 7 - j);
                        tileLabel.Name = $"Tile{oddTiles}";
                        tileLabel.Content = $"Tile{oddTiles}";
                        b.BorderBrush = new SolidColorBrush(Colors.Red);
                        tileLabel.Background = Brushes.Beige;
                        generatedLabels[oddTiles] = (tileLabel);
                        generatedPoints[oddTiles] = new System.Windows.Point(i, j);
                    }

                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(tileLabel, i);
                    Grid.SetColumn(tileLabel, j);

                    GooseGrid.Children.Add(tileLabel);
                    GooseGrid.Children.Add(b);
                }
            }
        }

        private int pointCounter { get; set; }

        public void SpiralBoard()
        {
            //for (int x = 0; x < 8; x++)
            //{
            //    for (int y = 0; y < 8; y++)
            //    {
            //        Label tilelabel = new();
            //        Grid.SetRow(tilelabel, y);
            //        Grid.SetColumn(tilelabel, x);
            //        tilelabel.Content += $"x:{x} - y:{y}";
            //        GooseGrid.Children.Add(tilelabel);
            //    }
            //}

            FillPointsLR(8, 7);
            FillPointsDU(7, 8, -1);
            FillPointsRL(7, 0);
            FillPointsUD(0, 7);

            FillPointsLR(6, 6, 1);
            FillPointsDU(6, 5, 1);
            FillPointsRL(7, 1);
            FillPointsUD(1, 4, 2);

            FillPointsLR(4, 5, 2);
            FillPointsDU(5, 4, 1);
            FillPointsRL(4, 2, 1);
            FillPointsUD(2, 2, 3);

            FillPointsLR(2, 4, 3);
            FillPointsLR(1, 3, 4);
            FillPointsLR(1, 3, 3);
        }

        private void FillPointsDU(int x, int y, int offSet = 0)
        {
            for (int j = y + offSet - 1; j > 0 + offSet; j--)
            {
                generatedPoints[pointCounter] = new System.Windows.Point(x, j);
                MakeGrid(x, j);
            }
        }

        private void FillPointsUD(int x, int y, int offSet = 0)
        {
            for (int j = 0 + offSet; j < y + offSet; j++)
            {
                generatedPoints[pointCounter] = new System.Windows.Point(x, j);
                MakeGrid(x, j);
            }
        }

        private void FillPointsRL(int x, int y, int offSet = 0)
        {
            for (int i = x + offSet - 1; i > 0 + offSet; i--)
            {
                generatedPoints[pointCounter] = new System.Windows.Point(i, y);
                MakeGrid(i, y);
            }
        }

        private void FillPointsLR(int x, int y, int offSet = 0)
        {
            for (int i = 0 + offSet; i < x + offSet; i++)
            {
                generatedPoints[pointCounter] = new System.Windows.Point(i, y);
                MakeGrid(i, y);
            }
        }

        private void MakeGrid(int x, int y)
        {
            Label tileLabel = new();
            Grid.SetRow(tileLabel, y);
            Grid.SetColumn(tileLabel, x);
            tileLabel.Content += $"Vak {pointCounter}";
            GooseGrid.Children.Add(tileLabel);
            pointCounter++;
        }

        //TODO Beetje uit elkaar halen

        private System.Drawing.Rectangle vierkantje = new();

        //HELP dit is hardcoded sorry Drawings en ControlElements doen moeilijk
        private void updatePlayerPositions()
        {
            int playerPosition = vm.GetPlayerPosition(0);
            int playerposX = (int)generatedPoints[playerPosition].X;
            int playerposY = (int)generatedPoints[playerPosition].Y;
            RectPlayer1.SetValue(Grid.RowProperty, playerposX);
            RectPlayer1.SetValue(Grid.ColumnProperty, playerposY);

            int playerPosition2 = vm.GetPlayerPosition(1);
            int playerposX2 = (int)generatedPoints[playerPosition2].X;
            int playerposY2 = (int)generatedPoints[playerPosition2].Y;
            RectPlayer2.SetValue(Grid.RowProperty, playerposX2);
            RectPlayer2.SetValue(Grid.ColumnProperty, playerposY2);

            int playerPosition3 = vm.GetPlayerPosition(2);
            int playerposX3 = (int)generatedPoints[playerPosition3].X;
            int playerposY3 = (int)generatedPoints[playerPosition3].Y;
            RectPlayer3.SetValue(Grid.RowProperty, playerposX3);
            RectPlayer3.SetValue(Grid.ColumnProperty, playerposY3);

            int playerPosition4 = vm.GetPlayerPosition(3);
            int playerposX4 = (int)generatedPoints[playerPosition4].X;
            int playerposY4 = (int)generatedPoints[playerPosition4].Y;
            RectPlayer4.SetValue(Grid.RowProperty, playerposX4);
            RectPlayer4.SetValue(Grid.ColumnProperty, playerposY4);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
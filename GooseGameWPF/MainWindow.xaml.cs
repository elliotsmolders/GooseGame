using GooseGame.Business;
using GooseGame.Business.Interfaces;
using GooseGameWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GooseGameWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Label[] generatedLabels = new Label[64];
        private System.Windows.Point[] generatedPoints = new System.Windows.Point[64];
        private System.Drawing.Rectangle vierkantje = new();
        private MainViewModel vm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            GooseGrid.DataContext = vm;
            vm.Init();
            StylelizeGridTiles();
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

        
        private void DisplayPlayerInfo()
        {
            Label[] PlayerLabel = new Label[] { PlayerLabel0, PlayerLabel1, PlayerLabel2, PlayerLabel3 };
            for (int i = 0; i < 4; i++)
            {
                PlayerLabel[i].Content = vm.GetPlayerName(i) + " is on " + vm.GetPlayerCurrentTileName(i);
            }
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

            vm.PlayTurn(roll1, roll2);

            vm.UpdateTurnLog();
            updatePlayerPositions();
            DisplayPlayerInfo();
            CheckForWinner();
        }
        private int[,] StylelizeGridTiles()

        {
            int[,] tileGrid = new int[8, 8];
            IList<ITile> tiles = GameBoard.GetGameBoard().Tiles;
            ITile[] gameBoardTilesPosition = new ITile[tiles.Count];


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int id = (i * 8) + j;
                   

                    Label tileLabel = new();
                    Border b = new();

                    b.BorderThickness = new Thickness(5);
                    tileLabel.HorizontalAlignment = HorizontalAlignment.Center;
                    tileLabel.VerticalAlignment = VerticalAlignment.Center;

                    if (i % 2 == 0)
                    {
                        int evenTiles = 63 - (i * 8 + j);
                        tileLabel.Name = $"Tile{evenTiles}";
                        tileLabel.Content = $"Tile{evenTiles}";
                        generatedLabels[evenTiles] = (tileLabel);
                        generatedPoints[evenTiles] = new System.Windows.Point(i, j);
                        gameBoardTilesPosition[evenTiles] = tiles[evenTiles];
                    }
                    else
                    {
                        int oddTiles = 63 - (i * 8 + 7 - j);
                        tileLabel.Name = $"Tile{oddTiles}";
                        tileLabel.Content = $"Tile{oddTiles}";
                        generatedLabels[oddTiles] = (tileLabel);
                        generatedPoints[oddTiles] = new System.Windows.Point(i, j);
                        gameBoardTilesPosition[oddTiles] = tiles[oddTiles];
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

                        //ImageBrush brush = new ImageBrush();
                        //ITile currentTile = gameBoardTilesPosition[id];
                        //brush.ImageSource = new BitmapImage(new Uri(gameBoardTilesPosition[i].BackgroundImage, UriKind.Relative));
                        
                    }

                    foreach (ITile tile in gameBoardTilesPosition)
                    {
                        ImageBrush brush = new ImageBrush();
                        brush.ImageSource = new BitmapImage(new Uri(tile.BackgroundImage, UriKind.Relative));
                        tileLabel.Background = brush;
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

        
        private void updatePlayerPositions()
        {
            System.Windows.Shapes.Rectangle[] RectPlayer = new System.Windows.Shapes.Rectangle[] { RectPlayer1, RectPlayer2, RectPlayer3, RectPlayer4 };
            int playerPosition, xx, yy;

            for (int i = 0; i < 4; i++)
            {
                playerPosition = vm.GetPlayerPosition(i);
                RectPlayer[i].SetValue(Grid.RowProperty, (int)generatedPoints[playerPosition].X);
                RectPlayer[i].SetValue(Grid.ColumnProperty, (int)generatedPoints[playerPosition].Y);
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using GooseGame.Business;
using GooseGame.Business.Interfaces;
using GooseGameWPF.ViewModels;

namespace GooseGameWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm;
        private Label[] generatedLabels = new Label[64];
        private System.Windows.Point[] generatedPoints = new System.Windows.Point[64];
        private System.Drawing.Rectangle vierkantje = new();

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            this.vm = viewModel;
            GooseGrid.DataContext = vm;
            StylelizeGridTiles();
            vm.Init();
        }

        private void GoToMenu(MainViewModel vm)
        {
            NavigationWindow window = new NavigationWindow();
            window.Source = new Uri("Menu.xaml", UriKind.Relative);
            window.Show();
            this.Visibility = Visibility.Hidden;
        }

        private bool CheckForWinner()
        {
            return vm.CheckForWinner();
        }

        private async Task WriteGameToDatabaseAsync()
        {
            await vm.WriteGameToDatabaseAsync();
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
            int roll1 = vm.RollDice();
            int roll2 = vm.RollDice();
            int currentRoll = roll1 + roll2;
            Roll1.Content = roll1;
            Roll2.Content = roll2;
            CurrentRoll.Content = currentRoll;
            vm.PlayTurn(roll1, roll2);
            string currentTile = vm.GetCurrentPlayerTile();
            CurrentPlayerTile.Content = currentTile;
            vm.UpdateTurnLog();
            updatePlayerPositions(vm.GetPlayerAmount());
            //UpdatePositionsAsync();
            CurrentPlayerLabel.Content = $"Player {DisplayCurrentPlayer()} is now playing";
            if (CheckForWinner())
            {
                FinalizeGame();
            }
            else
            {
                vm.SetNextPlayer();
            }
        }

        private async void FinalizeGame() //Needed to end the async chain for the event handler Upwards
        {
            string winnerName = vm.GetWinnerName();
            MessageBox.Show($"{winnerName} has wonnered!");
            GooseGrid.IsEnabled = false;
            await WriteGameToDatabaseAsync();
        }

        private int DisplayCurrentPlayer()
        {
            return vm.GetCurrentPlayerId();
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
                    Image tileBackground = new();
                    Label tileLabel = new();
                    Border b = new();
                    ImageBrush brush = new ImageBrush();

                    tileBackground.Width = 100;
                    tileBackground.Height = 100;
                    tileBackground.HorizontalAlignment = HorizontalAlignment.Center;
                    tileBackground.VerticalAlignment = VerticalAlignment.Center;

                    b.BorderThickness = new Thickness(2);
                    tileLabel.HorizontalAlignment = HorizontalAlignment.Center;
                    tileLabel.VerticalAlignment = VerticalAlignment.Center;

                    if (i % 2 == 0)
                    {
                        int evenTiles = 63 - (i * 8 + j);
                        tileLabel.Name = $"Tile{evenTiles}";
                        //tileLabel.Content = $"{evenTiles}";
                        generatedLabels[evenTiles] = (tileLabel);
                        generatedPoints[evenTiles] = new System.Windows.Point(i, j);
                        gameBoardTilesPosition[evenTiles] = tiles[evenTiles];
                        ImageSource tileImage = new BitmapImage(new Uri(gameBoardTilesPosition[evenTiles].BackgroundImage, UriKind.RelativeOrAbsolute));

                        tileBackground.Source = tileImage;
                    }
                    else
                    {
                        int oddTiles = 63 - (i * 8 + 7 - j);
                        tileLabel.Name = $"Tile{oddTiles}";
                        //tileLabel.Content = $"{oddTiles}";
                        generatedLabels[oddTiles] = (tileLabel);
                        generatedPoints[oddTiles] = new System.Windows.Point(i, j);
                        gameBoardTilesPosition[oddTiles] = tiles[oddTiles];
                        ImageSource tileImage = new BitmapImage(new Uri(gameBoardTilesPosition[oddTiles].BackgroundImage, UriKind.RelativeOrAbsolute));

                        tileBackground.Source = tileImage;
                    }

                    foreach (int pos in tileGrid)
                    {
                        b.BorderBrush = new SolidColorBrush(Colors.Black);
                    }

                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(tileLabel, i);
                    Grid.SetColumn(tileLabel, j);
                    Grid.SetRow(tileBackground, i);
                    Grid.SetColumn(tileBackground, j);
                    GooseGrid.Children.Add(tileBackground);
                    GooseGrid.Children.Add(tileLabel);
                    GooseGrid.Children.Add(b);
                }
            }
            return tileGrid;
        }

        //private void updatePlayerPosition()
        //{
        //    System.Windows.Shapes.Rectangle[] RectPlayer = new System.Windows.Shapes.Rectangle[] { RectPlayer0, RectPlayer1, RectPlayer2, RectPlayer3 };
        //    int playerPosition, xx, yy;
        //    int currentPlayer = 0;
        //    int playerPreviousPosition;
        //    int difference;

        //    currentPlayer = vm.GetCurrentPlayerId();
        //    playerPosition = vm.GetCurrentPlayerCurrentPosition();
        //    playerPreviousPosition = vm.GetCurrentPlayerPreviousPosition();
        //    difference = playerPosition - playerPreviousPosition;

        //    RectPlayer[currentPlayer].SetValue(Grid.RowProperty, (int)generatedPoints[playerPosition].X);
        //    RectPlayer[currentPlayer].SetValue(Grid.ColumnProperty, (int)generatedPoints[playerPosition].Y);
        //}

        private void updatePlayerPositions(int amountOfPlayers)
        {
            Image[] Player = new Image[] { Player0, Player1, Player2, Player3 };
            int playerPosition, xx, yy;

            for (int i = 0; i < amountOfPlayers; i++)
            {
                playerPosition = vm.GetPlayerPosition(i);
                Player[i].SetValue(Grid.RowProperty, (int)generatedPoints[playerPosition].X);
                Player[i].SetValue(Grid.ColumnProperty, (int)generatedPoints[playerPosition].Y);
            }
        }

        private void Grid_Keydown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string sanitizedString = e.Key.ToString().Replace("D", "");
            if (!IsANumber(sanitizedString))
            {
                MessageBox.Show(e.Key.ToString());
                e.Handled = true;
            }
            else
            {
                int roll1 = int.Parse(sanitizedString);
                int roll2 = 0;
                vm.PlayTurn(roll1, roll2);
                string currentTile = vm.GetCurrentPlayerTile();
                CurrentPlayerTile.Content = currentTile;
                vm.UpdateTurnLog();
                updatePlayerPositions(vm.GetPlayerAmount());
                CurrentPlayerLabel.Content = $"Player {DisplayCurrentPlayer()} is now playing";
                CheckForWinner();
                vm.SetNextPlayer();
                //MessageBox.Show(sanitizedString);
            }
        }

        private bool IsANumber(string input)
        {
            int output;
            return int.TryParse(input, out output);
        }

        private void UpdatePositionsAsync()
        {
            var bw = new BackgroundWorker();
            int iMin = vm.GetCurrentPlayerCurrentPosition();
            int iMax = vm.GetCurrentPlayerCurrentPosition() + (int)CurrentRoll.Content;
            var xamlPlayer = Player0;
            switch (vm.CurrentSequence())
            {
                case 0:
                    xamlPlayer = Player0;
                    break;

                case 1:
                    xamlPlayer = Player1;
                    break;

                case 2:
                    xamlPlayer = Player2;
                    break;

                case 4:
                    xamlPlayer = Player3;
                    break;
            }
            List<object> arguments = new List<object>
            {
                xamlPlayer,
                iMin,
                iMax
            };
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync(arguments);
        }

        private void Bw_DoWork(object? sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;

            Image Player = (Image)genericlist[0];
            int iMin = (int)genericlist[1];
            int iMax = (int)genericlist[2];
            for (int i = iMin; i < iMax; i++)
            {
                SetLocation(Player);
                System.Threading.Thread.Sleep(300);
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/15504826/invokerequired-in-wpf
        /// </summary>
        /// <param name="playerIcon"></param>
        /// <param name="p"></param>
        private delegate void ParametrizedMethodInvoker5(Image Player);

        private void SetLocation(Image Player)
        {
            if (!Dispatcher.CheckAccess()) // CheckAccess returns true if you're on the dispatcher thread
            {
                Dispatcher.Invoke(new ParametrizedMethodInvoker5(SetLocation), Player);
                return;
            }

            int playerPosition = vm.GetCurrentPlayerCurrentPosition();
            Player.SetValue(Grid.RowProperty, (int)generatedPoints[playerPosition].X);
            Player.SetValue(Grid.ColumnProperty, (int)generatedPoints[playerPosition].Y);
        }
    }
}
using GooseGameWPF.Entities;
using GooseGameWPF.ViewModels;
using System.Collections.Generic;
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
        List<PlayerModel> players = new List<PlayerModel>();

        public MainWindow()
        {
            InitializeComponent();
            GooseGrid.DataContext = vm;
            vm.Init();
            StylelizeGridTiles();
            players.Add(new PlayerModel { Name = "Arno", PlayerIcon = 1 });
            players.Add(new PlayerModel { Name = "Bart", PlayerIcon = 2 });
            players.Add(new PlayerModel { Name = "Elliot", PlayerIcon = 3 });
            players.Add(new PlayerModel { Name = "Ken", PlayerIcon = 4 });

            vm.SetPlayerPosition(0, 7);
            vm.SetPlayerPosition(1, 22);
            vm.SetPlayerPosition(2, 43);
            vm.SetPlayerPosition(3, 25);

            updatePlayerIconPosition();
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            updateCurrentPlayerPosition();
            vm.SetNextPlayer();

            Roll1.Content = vm.RollDice();
            Roll2.Content = vm.RollDice();

            CurrentRoll.Content = vm.RollDice();

            vm.PlayTurn((int)Roll1.Content, (int)Roll2.Content);
            Debug.Content = vm.GetCurrentPlayerPositionAndName();
        }

        private Label[] generatedLabels = new Label[64];
        private Point[] generatedPoints = new Point[64];

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
                        generatedPoints[evenTiles] = new Point(i, j);
                    }
                    else
                    {
                        int oddTiles = 63 - (i * 8 + 7 - j);
                        tileLabel.Name = $"Tile{oddTiles}";
                        tileLabel.Content = $"Tile{oddTiles}";
                        generatedLabels[oddTiles] = (tileLabel);
                        generatedPoints[oddTiles] = new Point(i, j);
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




        public int[,] NumberToRowColumn(int numberToConvert)
        {
            int row;
            int column;
            row = numberToConvert / 8;
            if (row % 2 == 0)
            {
                column = numberToConvert % 8;
            }
            else
            {
                column = 8 - (numberToConvert % 8);
            }
            int[,] tilePoints = new int[row, column];
            return tilePoints;
        }

        //TODO Beetje uit elkaar halen
        private void updateCurrentPlayerPosition()
        {
            int currentPos = vm.GetCurrentPlayerPosition();
            var currentLabel = $"Tile{currentPos}";
            int playerposX = (int)generatedPoints[currentPos].X;
            int playerposY = (int)generatedPoints[currentPos].Y;
            RectPlayer.SetValue(Grid.RowProperty, playerposX);
            RectPlayer.SetValue(Grid.ColumnProperty, playerposY);
        }

        private void updatePlayerIconPosition()
        {
            int teller = 0;
            List<Grid> playerGrids = new List<Grid>() { Player1, Player2, Player3, Player4 };
            foreach (PlayerModel player in players)
            {
                int currentPos = vm.GetPlayerPosition(teller);
                int playerposX = (int)generatedPoints[currentPos].X;
                int playerposY = (int)generatedPoints[currentPos].Y;
                playerGrids[teller].SetValue(Grid.RowProperty, playerposX);
                playerGrids[teller].SetValue(Grid.ColumnProperty, playerposY);
                teller++;
            }
        }


        //    private void assignPlayerIcon()
        //    {
        //        vm.assignPlayerIcon();
        //    }
        //}
    }
}
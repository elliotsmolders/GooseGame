using GooseGameWPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

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
            LabelGridTiles();
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            vm.SetNextPlayer();
            Roll1.Content = vm.RollDice();
            Roll2.Content = vm.RollDice();
            CurrentRoll.Content = vm.RollDice();

            //vm.PlayTurn((int)Roll1.Content,(int)Roll2.Content);
            Debug.Content = vm.GetCurrentPlayerPositionAndName();
        }

        private void LabelGridTiles()

        {
            int[,] myGrid = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Label tileLabel = new();
                    if (i % 2 == 0)
                    {
                        tileLabel.Content = (63 - (i * 8 + j)).ToString();
                    }
                    else
                    {
                        tileLabel.Content = (63 - (i * 8 + 7 - j)).ToString();
                        Console.Write($"{myGrid[i, j]}\t");
                    }
                    Grid.SetRow(tileLabel, i);
                    Grid.SetColumn(tileLabel, j);

                    GooseGrid.Children.Add(tileLabel);
                }
          
            }
        }
    }
}
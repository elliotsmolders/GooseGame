﻿using GooseGameWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            vm.SetNextPlayer();
            updateCurrentPlayerPosition();
            Roll1.Content = vm.RollDice();
            Roll2.Content = vm.RollDice();
            CurrentRoll.Content = vm.RollDice();
            
            
            vm.PlayTurn((int)Roll1.Content,(int)Roll2.Content);
            Debug.Content = vm.GetCurrentPlayerPositionAndName();

        }


        Label[] generatedLabels = new Label[64];

        private int[,]  StylelizeGridTiles()
                    
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
                        

                    }
                    else
                    {
                        int oddTiles = 63 - (i * 8 + 7 - j);
                        tileLabel.Name = $"Tile{oddTiles}";
                        tileLabel.Content = $"Tile{oddTiles}";
                        generatedLabels[oddTiles] = (tileLabel);

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

        private void updateCurrentPlayerPosition()
        {
          int currentPos = vm.GetPlayerPosition();
            var currentLabel = $"Tile{currentPos}";
            

            //MessageBox.Show($"{currentPos} playerpos and {currentLabel}");
            generatedLabels[currentPos].Content = $"player here! ";

            generatedLabels[currentPos].Background = Brushes.Pink;
            Border b = new();

            b.BorderThickness = new Thickness(20);
            generatedLabels[currentPos].BorderBrush = new SolidColorBrush(Colors.Green);
        }
    }
}
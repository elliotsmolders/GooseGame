using GooseGame.Business;
using GooseGameWPF.ViewModels;
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
        }

        public void SelectPlayers()
        {
            vm.SelectPlayers();
        }

        /// <summary>
        /// Voor het spel start kunnen spelers toegevoegd worden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task AddPlayerAsync_Click(object sender, RoutedEventArgs e)
        {
            var Playername = PlayerName.Text;
            vm.AddPlayerAsync(Playername);
        }

        public async Task PrepareNewGameAsync()
        {
            vm.InstantiatePlayers();
            await vm.InstantiateGameAsync();
        }

        public void LoadGame()
        {
            vm.LoadGame();
        }

        public void ShowHighScores()
        {
        }

        /// <summary>
        /// Na game initializing Zien we het bord en zien we de Roll dice knop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            Tuple<int, int> dice = vm.RollDice();
            var roll1 = dice.Item1;
            var roll2 = dice.Item2;

            Roll1.Content = roll1;
            Roll2.Content = roll2;
            CurrentRoll.Content = roll1 + roll2;

            vm.PlayTurn(); //2 dice die elk nummer bijhouden geupdate door de Engine
            Debug.Content = vm.GetCurrentPlayerPositionAndName();
        }
    }
}
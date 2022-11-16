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
            vm.Init();
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            vm.GetNextPlayer();
            Roll1.Content = vm.RollDice();
            Roll2.Content = vm.RollDice();
            CurrentRoll.Content = (int)Roll1.Content + (int)Roll2.Content;
            vm.PlayTurn((int)CurrentRoll.Content);
            Debug.Content = vm.GetCurrentPlayerPositionAndName();
        }
    }
}
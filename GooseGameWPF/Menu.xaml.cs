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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private MainViewModel vm = new MainViewModel();

        public Menu()
        {
            InitializeComponent();
            vm = new MainViewModel();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Visibility = Visibility.Visible;
            Window win = (Window)this.Parent;
            win.Close();
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            vm.AddPlayer(PlayerNameInput.Text);
            PlayerNameInput.Text = "";
        }
    }
}
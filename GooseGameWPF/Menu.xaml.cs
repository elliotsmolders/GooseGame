using GooseGameWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            IconSelect.Items.Add(new IconBuilder(new BitmapImage(new Uri("Resources/Icons/icon1.bmp", UriKind.Relative))));
            IconSelect.Items.Add(new IconBuilder(new BitmapImage(new Uri("Resources/Icons/icon2.bmp", UriKind.Relative))));
            IconSelect.Items.Add(new IconBuilder(new BitmapImage(new Uri("Resources/Icons/icon3.bmp", UriKind.Relative))));
            IconSelect.Items.Add(new IconBuilder(new BitmapImage(new Uri("Resources/Icons/icon4.bmp", UriKind.Relative))));
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            int playeramount;
            if (PlayerAmount.SelectedIndex > -1)
            {
                bool test = int.TryParse(PlayerAmount.Text, out playeramount);
            }
            else
            {
                throw new ArgumentException("Invalid amount of players selected", nameof(PlayerAmount) + PlayerAmount);
            }
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Visibility = Visibility.Visible;
            Window win = (Window)this.Parent;
            win.Close();
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            vm.AddPlayer(PlayerNameInput.Text, IconSelect.SelectedIndex + 1);
            PlayerNameInput.Text = "";
        }
    }
}
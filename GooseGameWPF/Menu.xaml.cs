using GooseGameWPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            IconSelect.Items.Add(new IconBuilder(new BitmapImage(new Uri("Resources/Icons/icon1.bmp", UriKind.Relative)), "icon 1"));
            IconSelect.Items.Add(new IconBuilder(new BitmapImage(new Uri("Resources/Icons/icon2.bmp", UriKind.Relative)), "icon 2"));
            IconSelect.Items.Add(new IconBuilder(new BitmapImage(new Uri("Resources/Icons/icon3.bmp", UriKind.Relative)), "icon 3"));
            IconSelect.Items.Add(new IconBuilder(new BitmapImage(new Uri("Resources/Icons/icon4.bmp", UriKind.Relative)), "icon 4"));
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
            MainWindow mainWindow = new MainWindow(vm);
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
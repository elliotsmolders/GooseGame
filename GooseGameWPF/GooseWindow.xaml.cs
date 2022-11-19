using GooseGameWPF.Drawing;
using GooseGameWPF.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace GooseGameWPF
{
    /// <summary>
    /// Interaction logic for GooseWindow.xaml
    /// </summary>
    public partial class GooseWindow : Window
    {
        private MainViewModel vm = new MainViewModel();

        public GooseWindow()
        {
            InitializeComponent();
            GooseGrid.DataContext = vm;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync(iconPlayer1);
        }

        private void Bw_DoWork(object? sender, DoWorkEventArgs e)
        {
            Image playerIcon = (Image)e.Argument!;

            //for (int i = 1; i <= 4; i++)
            //{
            //    SetLocation(playerIcon, GooseBoard.GetStartPosition(i));
            //    System.Threading.Thread.Sleep(1000);
            //}

            for (int i = 1; i <= 7; i++)
            {
                SetLocation(playerIcon, GooseBoard.GetFieldPosition(i));
                System.Threading.Thread.Sleep(300);
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/15504826/invokerequired-in-wpf
        /// </summary>
        /// <param name="playerIcon"></param>
        /// <param name="p"></param>
        private delegate void ParametrizedMethodInvoker5(Image playerIcon, System.Drawing.Point p);

        private void SetLocation(Image playerIcon, System.Drawing.Point p)
        {
            if (!Dispatcher.CheckAccess()) // CheckAccess returns true if you're on the dispatcher thread
            {
                Dispatcher.Invoke(new ParametrizedMethodInvoker5(SetLocation), playerIcon, p);
                return;
            }

            var margin = playerIcon.Margin;
            margin.Left = p.X;
            margin.Top = p.Y;
            playerIcon.Margin = margin;
        }
    }
}
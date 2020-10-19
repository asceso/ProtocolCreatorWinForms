using Prism.Regions;
using ProtocolerWPF.ViewModels;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace ProtocolerWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Ctor
        public MainWindow()
        {
            InitializeComponent();
        }
        //After initialize components loading start View
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as MainWindowViewModel;
            viewModel.AfterInit();
        }
        #region Mouse drag move window
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton.Equals(MouseButtonState.Pressed))
                return;
            if (e.LeftButton.Equals(MouseButtonState.Pressed) && e.ClickCount.Equals(2))
            { 
                WindowState = WindowState.Equals(WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
                return;
            }
            this.Cursor = Cursors.ScrollAll;
            this.DragMove();
            this.Cursor = Cursors.Arrow;
        }
        #endregion Mouse drag move window
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProtocolViewer.Views
{
    /// <summary>
    /// Логика взаимодействия для ProtocolsView.xaml
    /// </summary>
    public partial class ProtocolsView : UserControl
    {
        public ProtocolsView()
        {
            InitializeComponent();
        }
        private void OnSelectAllTextButtonClick(object sender, RoutedEventArgs e)
        {
            PreviewBufferName.Focus();
            PreviewBufferName.SelectAll();
        }
        private void OnCopyClipboardClick(object sender, RoutedEventArgs e)
        {
            if (PreviewBufferName.SelectedText.Equals(string.Empty))
                return;
            Clipboard.SetText(PreviewBufferName.SelectedText);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                var border = (Border)VisualTreeHelper.GetChild(listBox, 0);
                var scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }
        }

        private void ListBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
                (sender as ListBox).SelectedIndex = -1;
        }
    }
}

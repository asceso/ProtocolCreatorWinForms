using System.Windows;
using System.Windows.Controls;

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
            if (!e.AddedItems.Count.Equals(0))
                (sender as ListBox).ScrollIntoView(e.AddedItems[0]);
        }
    }
}

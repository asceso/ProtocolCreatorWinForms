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

namespace ProtocolViewer.Views
{
    /// <summary>
    /// Логика взаимодействия для ProtocolGeneratedView.xaml
    /// </summary>
    public partial class ProtocolGeneratedView : UserControl
    {
        public ProtocolGeneratedView()
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
    }
}

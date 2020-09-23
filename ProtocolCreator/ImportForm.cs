using System.Windows.Forms;

namespace ProtocolCreator
{
    public partial class ImportForm : Form
    {
        private const string DefaultText = "Для импорта наберите текст в буфер.";
        public string ImportBuffer { get; private set; }
        public ImportForm()
        {
            InitializeComponent();
            SetDefaultText();
        }
        private void SetDefaultText()
        {
            importBuffer.Text = DefaultText;
            importBuffer.DeselectAll();
        }
        private void ImportBuffer_TextChanged(object sender, System.EventArgs e)
        {
            importButton.Enabled = !string.IsNullOrEmpty(importBuffer.Text) && !importBuffer.Text.Equals(DefaultText);
        }
        private void importButton_Click(object sender, System.EventArgs e)
        {
            ImportBuffer = importBuffer.Text;
            this.Close();
        }
    }
}

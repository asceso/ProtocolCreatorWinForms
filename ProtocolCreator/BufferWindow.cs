using System;
using System.IO;
using System.Windows.Forms;

namespace ProtocolCreator
{
    public partial class BufferWindow : Form
    {
        private string id;
        public BufferWindow(string buffer, string id)
        {
            InitializeComponent();
            bufferTextBox.Text = buffer;
            this.id = id;
        }
        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(bufferTextBox.Text);
        }
        private void ExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Протокол (*.txt) | *.txt";
            saveFile.Title = "Экспорт протокола";
            saveFile.FileName = id;
            saveFile.InitialDirectory = Environment.CurrentDirectory;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                {
                    writer.Write(bufferTextBox.Text);
                }
            }
            else
                return;
        }
    }
}

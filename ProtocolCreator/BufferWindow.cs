using ProtocolCreator.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace ProtocolCreator
{
    public partial class BufferWindow : Form
    {
        private readonly string id;
        private readonly SettingsModel settings;
        public BufferWindow(string buffer, string id, string idCollection, SettingsModel settings)
        {
            InitializeComponent();
            bufferTextBox.Text = buffer;
            idCollectionTextBox.Text = idCollection;
            this.id = id;
            this.settings = settings;
        }
        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(idCollectionTextBox.Text);
        }
        private void ExportButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog
            {
                SelectedPath = settings.DefaultProtocolPath,
                Description = "Выбор папки для сохранения"
            };
            string currentPath;
            if (DialogResult.OK == folder.ShowDialog())
            {
                currentPath = folder.SelectedPath;
            }
            else
                return;
            using (StreamWriter writer = new StreamWriter(currentPath + "\\" + id + ".txt"))
            {
                writer.Write(bufferTextBox.Text);
            }
        }
    }
}

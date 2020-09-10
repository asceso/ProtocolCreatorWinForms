using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtocolCreator
{
    public partial class BufferWindow : Form
    {
        public BufferWindow(string buffer)
        {
            InitializeComponent();
            bufferTextBox.Text = buffer;
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(bufferTextBox.Text);
        }
    }
}

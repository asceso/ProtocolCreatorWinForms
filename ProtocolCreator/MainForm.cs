using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProtocolCreator
{
    public partial class MainForm : Form
    {
        #region fields
        private ObservableCollection<ProtocolElementModel> protocolElements;
        private string fileName = "новый протокол";
        private readonly string TemplateProtocol;
        #endregion

        #region ctor

        public MainForm()
        {
            InitializeComponent();
            protocolElements = new ObservableCollection<ProtocolElementModel>();
            protocolElements.CollectionChanged += ElemenetsCollectionChanged;
            this.Text = "Creator - " + fileName;
            saveToFileButton.ToolTipText = "Нельзя сохранять пустой файл.";
            TemplateProtocol = CreateTemplate();
        }

        #endregion Ctor

        #region Template creation
        private string CreateTemplate()
        {
            StringBuilder template = new StringBuilder();
            using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + "\\Templates\\ProtocolTemplate.txt"))
            {
                while (!reader.EndOfStream)
                {
                    template.Append(reader.ReadLine() + Environment.NewLine);
                }
            }
            return template.ToString().Remove(template.ToString().LastIndexOf(Environment.NewLine));
        }
        #endregion Template creation

        #region buttons

        private void SaveButton_Click(object sender, EventArgs e) => OnSave();
        private void AddButton_Click(object sender, EventArgs e) => OnAdd();
        private void DeleteButton_Click(object sender, EventArgs e) => OnDelete();

        #endregion

        #region buttons Methods
        private void OnAdd()
        {
            ProtocolElementModel model = new ProtocolElementModel();
            protocolElements.Add(model);
        }

        private void OnDelete()
        {
            protocolElements.Remove(protocolElements[protocolList.SelectedIndex]);
        }

        private void OnSave()
        {
            saveButton.Enabled = false;
            ProtocolElementModel newModel = new ProtocolElementModel();
            newModel.ID = idTextBox.Text;
            newModel.Name = nameTextBox.Text;
            newModel.Value = valueTextBox.Text;
            protocolElements[protocolList.SelectedIndex] = newModel;
        }

        #endregion

        #region collection events
        private void ElemenetsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        ProtocolElementModel protocol = e.NewItems[0] as ProtocolElementModel;
                        protocolList.Items.Add(protocol.ID);
                        protocolList.SelectedIndex = protocolList.Items.Count - 1;
                        
                        idTextBox.Text = protocol.ID;
                        nameTextBox.Text = protocol.Name;
                        valueTextBox.Text = protocol.Value;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        protocolList.Items.RemoveAt(protocolList.SelectedIndex);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    {
                        ProtocolElementModel protocol = e.NewItems[0] as ProtocolElementModel;
                        protocolList.Items[protocolList.SelectedIndex] = protocol.ID;

                        idTextBox.Text = protocol.ID;
                        nameTextBox.Text = protocol.Name;
                        valueTextBox.Text = protocol.Value;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    {
                        protocolList.Items.Clear();

                        idTextBox.Clear();
                        nameTextBox.Clear();
                        valueTextBox.Clear();
                    }
                    break;
            }
            createButton.Enabled = protocolList.Items.Count == 0 ? false : true;
            saveToFileButton.Enabled = protocolList.Items.Count == 0 ? false : true;
            saveToFileButton.ToolTipText = !saveToFileButton.Enabled ? "Нельзя сохранять пустой файл." : string.Empty;
        }

        #endregion

        #region listbox events

        private void ProtocolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (protocolList.SelectedIndex == -1)
            {
                idTextBox.Clear();
                nameTextBox.Clear();
                valueTextBox.Clear();
            }
            else
            {
                idTextBox.Text = protocolElements[protocolList.SelectedIndex].ID;
                nameTextBox.Text = protocolElements[protocolList.SelectedIndex].Name;
                valueTextBox.Text = protocolElements[protocolList.SelectedIndex].Value;
            }
            deleteButton.Enabled = protocolList.SelectedIndex == -1 ? false : true;
        }

        private void ProtocolList_MouseClick(object sender, MouseEventArgs e)
        {
            int index = protocolList.IndexFromPoint(new Point(e.X, e.Y));
            protocolList.SelectedIndex = index;
        }

        private void Item_TextChanged(object sender, EventArgs e)
        {
            if (protocolList.SelectedIndex != -1)
                saveButton.Enabled = (
                    idTextBox.Text != protocolElements[protocolList.SelectedIndex].ID ||
                    nameTextBox.Text != protocolElements[protocolList.SelectedIndex].Name ||
                    valueTextBox.Text != protocolElements[protocolList.SelectedIndex].Value
                    ) ? true : false;
            else
                saveButton.Enabled = false;
        }

        #endregion

        #region create
        private void CreateButton_Click(object sender, EventArgs e)
        {
            BufferWindow buffer = new BufferWindow(OnCreate(), IDprotocolTextBox.Text);
            buffer.ShowDialog();
        }
        private string OnCreate()
        {
            StringBuilder result = new StringBuilder();
            //header
            result.Append(TemplateProtocol);
            result.Replace("TMP_ID_REPLACE", IDprotocolTextBox.Text);
            result.Replace("TMP_NAME_REPLACE", nameProtocolTextBox.Text);
            result.Replace("TMP_HEADER_VALUE_REPLACE", headerProtocolTextBox.Text);
            //body
            StringBuilder body = new StringBuilder();
            foreach (ProtocolElementModel item in protocolElements)
            {
                body.Append("  <TextBox ");
                body.Append($"Id=\"{item.ID}\" ");
                string nameText = string.IsNullOrEmpty(item.Name) ? string.Empty : $"Name=\"{item.Name}\" ";
                body.Append(nameText);
                body.Append("ItemType=\"TextBox\" IsEnabled=\"true\" IsVisible=\"true\" ");
                body.Append($"Value=\"{item.Value}\" MinWidth=\"60\" Lines=\"2\" />");
                body.Append(Environment.NewLine);
            }
            result.Replace("TMP_BODY_REPLACE", body.ToString().Remove(body.ToString().LastIndexOf(Environment.NewLine)));
            //footer
            result.Replace("TMP_CONCLUSION_REPLACE", conclusionTextBox.Text);
            return result.ToString();
        }
        #endregion

        #region menu buttons

        private void NewFileButton_Click(object sender, EventArgs e)
        {
            if (protocolElements.Count != 0)
            {
                if (MessageBox.Show("Текущий протокол будет удален, сохранить перед закрытием?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    saveToFileButton.PerformClick();
            }
            protocolElements.Clear();
        }

        private void OpenFromFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JSon протокол (*.json) | *.json";
            openFile.Title = "Открыть протокол";
            openFile.InitialDirectory = Environment.CurrentDirectory;
            string buffer = string.Empty;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFile.FileName))
                {
                    buffer = reader.ReadToEnd();
                }
            }
            else
                return;
            fileName = openFile.FileName
                   .Remove(0, openFile.FileName.LastIndexOf('\\') + 1)
                   .Replace(".json", string.Empty);
            this.Text = "Creator - " + fileName;

            if (protocolElements.Count != 0)
            {
                if (MessageBox.Show("Текущий протокол будет удален, сохранить перед закрытием?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    saveToFileButton.PerformClick();
            }
            ProtocolFullModel protocol = JsonConvert.DeserializeObject<ProtocolFullModel>(buffer);

            IDprotocolTextBox.Text = protocol.ID;
            nameProtocolTextBox.Text = protocol.Name;
            headerProtocolTextBox.Text = protocol.ProtocolHeader;
            conclusionTextBox.Text = protocol.Conclusion;

            protocolElements.Clear();
            foreach (ProtocolElementModel item in protocol.Elements)
            {
                protocolElements.Add(item);
            }
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            ProtocolFullModel protocol = new ProtocolFullModel
            {
                ID = IDprotocolTextBox.Text,
                Name = nameProtocolTextBox.Text,
                ProtocolHeader = headerProtocolTextBox.Text,
                Conclusion = conclusionTextBox.Text,
                Elements = protocolElements.ToList()
            };
            string jsonFile = JsonConvert.SerializeObject(protocol, Formatting.Indented);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "JSon протокол (*.json) | *.json";
            saveFile.Title = "Сохранение протокола";
            saveFile.InitialDirectory = Environment.CurrentDirectory;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                {
                    writer.Write(jsonFile);
                }
            }
            else
                return;
            fileName = saveFile.FileName
                .Remove(0, saveFile.FileName.LastIndexOf('\\') + 1)
                .Replace(".json", string.Empty);
            this.Text = "Creator - " + fileName;
            MessageBox.Show("Сохранение файла прошло успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}

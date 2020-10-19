using Newtonsoft.Json;
using ProtocolCreator.Models;
using ProtocolCreator.Properties;
using ProtocolCreator.Translate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtocolCreator
{
    public partial class MainForm : Form
    {
        #region fields
        private readonly ObservableCollection<ProtocolElementModel> protocolElements;
        private readonly SettingsModel settings;
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
            settings = SettingsLogic.GetConfig(Environment.CurrentDirectory + "\\AppSettings.json");
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
        private async void TranslateIDTextBox_Click(object sender, EventArgs e)
        {
            translateIDTextBox.Image = Resources.loading;
            string translated = string.Empty;
            await Task.Run(() => translated = TextTranslator.TranslateToEng(idTextBox.Text));
            idTextBox.Text = translated;
            idTextBox.DeselectAll();
            translateIDTextBox.Image = Resources.translate;
        }
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
            ProtocolElementModel newModel = new ProtocolElementModel
            {
                ID = idTextBox.Text,
                Name = nameTextBox.Text,
                Value = valueTextBox.Text
            };
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
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() => OnAddElement(protocol)));
                            return;
                        }
                        else
                        {
                            OnAddElement(protocol);
                            return;
                        }
                    }
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
            createButton.Enabled = protocolList.Items.Count != 0;
            saveToFileButton.Enabled = protocolList.Items.Count != 0;
            saveToFileButton.ToolTipText = !saveToFileButton.Enabled ? "Нельзя сохранять пустой файл." : string.Empty;
        }
        private void OnAddElement(ProtocolElementModel protocol)
        {
            protocolList.Items.Add(protocol.ID);
            protocolList.SelectedIndex = protocolList.Items.Count - 1;

            idTextBox.Text = protocol.ID;
            nameTextBox.Text = protocol.Name;
            valueTextBox.Text = protocol.Value;

            createButton.Enabled = protocolList.Items.Count != 0;
            saveToFileButton.Enabled = protocolList.Items.Count != 0;
            saveToFileButton.ToolTipText = !saveToFileButton.Enabled ? "Нельзя сохранять пустой файл." : string.Empty;
            mergeAllBtn.Enabled = protocolList.Items.Count > 1;
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
            deleteButton.Enabled = protocolList.SelectedIndex != -1;
            deleteContextMenu.Enabled = protocolList.SelectedIndex != -1;
            deleteAllContext.Enabled = protocolList.SelectedIndex != -1;
        }
        private void ProtocolList_MouseClick(object sender, MouseEventArgs e)
        {
            int index = protocolList.IndexFromPoint(new Point(e.X, e.Y));
            protocolList.SelectedIndex = index;
        }
        private void ProtocolList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && deleteButton.Enabled)
                deleteButton.PerformClick();
        }
        private void Item_TextChanged(object sender, EventArgs e)
        {
            if (protocolList.SelectedIndex != -1)
                saveButton.Enabled = (
                    idTextBox.Text != protocolElements[protocolList.SelectedIndex].ID ||
                    nameTextBox.Text != protocolElements[protocolList.SelectedIndex].Name ||
                    valueTextBox.Text != protocolElements[protocolList.SelectedIndex].Value
                    );
            else
                saveButton.Enabled = false;
            while (valueTextBox.Text.Contains("\""))
            {
                valueTextBox.Text = valueTextBox.Text.Replace("\"", "'");
            }
            while (valueTextBox.Text.Contains(">"))
            {
                valueTextBox.Text = valueTextBox.Text.Replace(">", "&#707;");
            }
            while (valueTextBox.Text.Contains("<"))
            {
                valueTextBox.Text = valueTextBox.Text.Replace("<", "&#706;");
            }

        }
        #endregion

        #region create
        private void CreateButton_Click(object sender, EventArgs e)
        {
            StringBuilder idCollection = new StringBuilder();
            foreach (var item in protocolElements)
            {
                idCollection.Append(item.ID + Environment.NewLine);
            }
            BufferWindow buffer = new BufferWindow(OnCreate(), IDprotocolTextBox.Text, idCollection.ToString(), settings);
            buffer.ShowDialog();
        }
        private void exportTxtButton_Click(object sender, EventArgs e)
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
            OnExportTxt(currentPath + "\\" + IDprotocolTextBox.Text + ".txt");
        }
        private void OnExportTxt(string filename, bool Silent = false)
        {
            string buffer = OnCreate();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.Write(buffer);
            }
            if (Silent)
                return;
            MessageBox.Show("Протокол экспортирован", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            OnNewFileClick();
        }
        private void OnNewFileClick(bool Silent = false)
        {
            if (protocolElements.Count != 0)
            {
                if (!Silent)
                {
                    if (MessageBox.Show("Имеются не сохраненные данные, продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        protocolElements.Clear();
                        IDprotocolTextBox.Clear();
                        nameProtocolTextBox.Clear();
                        headerProtocolTextBox.Clear();
                        conclusionTextBox.Clear();
                    }
                }
                else
                {
                    protocolElements.Clear();
                    IDprotocolTextBox.Clear();
                    nameProtocolTextBox.Clear();
                    headerProtocolTextBox.Clear();
                    conclusionTextBox.Clear();
                }
            }
            else
            {
                saveToFileButton.PerformClick();
            }
        }
        private void OpenFromFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "JSon протокол (*.json) | *.json",
                Title = "Открыть протокол",
                InitialDirectory = settings.DefaultProtocolPath
            };
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
        private void OpenFromTxtBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "Код протокола (*.txt) | *.txt",
                Title = "Открыть код протокола",
                InitialDirectory = settings.DefaultProtocolPath
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFile.FileName))
                {
                    OnOpenTxt(openFile.FileName);
                }
            }
            else
                return;
        }
        private void OnOpenTxt(string filename, bool Silent = false)
        {
            OnNewFileClick(Silent);

            #region open file
            string buffer = string.Empty;
            using (StreamReader reader = new StreamReader(filename))
            {
                buffer = reader.ReadToEnd();
            }
            if (!buffer.Contains("ProtocolName"))
            {
                MessageBox.Show(
                    "Протокол не содержит в себе поля ProtocolName.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
                #endregion open file

            string[] fileStrings = buffer.Split('\n');

            #region FillTextBoxes
            IDprotocolTextBox.Text = fileStrings
                .FirstOrDefault(i => i.Contains("<Id>"))
                .Trim()
                .Replace("<Id>", string.Empty)
                .Replace("</Id>", string.Empty);

            nameProtocolTextBox.Text = fileStrings
                .FirstOrDefault(i => i.Contains("<Name>"))
                .Trim()
                .Replace("<Name>", string.Empty)
                .Replace("</Name>", string.Empty);

            var protocolNameBuffer = fileStrings
                .FirstOrDefault(i => i.Contains("Id=\"ProtocolName\""))
                .Trim();

            var protocolName = protocolNameBuffer.Substring(protocolNameBuffer.IndexOf("Value=\"") + "Value=\"".Length);
            protocolName = protocolName.Remove(protocolName.IndexOf('\"'));

            headerProtocolTextBox.Text = protocolName;

            var conclusionBuffer = fileStrings
                .FirstOrDefault(i => i.Contains("Id=\"Conclusion\""))
                .Trim();

            var conclusionText = conclusionBuffer.Substring(conclusionBuffer.IndexOf("Value=\"") + "Value=\"".Length);
            conclusionText = conclusionText.Remove(conclusionText.IndexOf('\"'));

            conclusionTextBox.Text = conclusionText;
            #endregion FillTextboxes

            #region FillElements
            int startIndex = Array.IndexOf(fileStrings, fileStrings.FirstOrDefault(i => i.Contains("Id=\"ProtocolName\""))) + 1;
            int endIndex = Array.IndexOf(fileStrings, fileStrings.FirstOrDefault(i => i.Contains("Id=\"Conclusion\"")));

            for (int i = startIndex; i < endIndex; i++)
            {
                var tmpID = fileStrings[i].Trim();
                tmpID = tmpID.Substring(tmpID.IndexOf("Id=\"") + "Id=\"".Length);
                tmpID = tmpID.Remove(tmpID.IndexOf('\"'));

                var tmpName = fileStrings[i].Trim();
                if (!tmpName.Contains("Name=\""))
                    tmpName = string.Empty;
                else
                {
                    tmpName = tmpName.Substring(tmpName.IndexOf("Name=\"") + "Name=\"".Length);
                    tmpName = tmpName.Remove(tmpName.IndexOf('\"'));
                }

                var tmpValue = fileStrings[i].Trim();
                tmpValue = tmpValue.Substring(tmpValue.IndexOf("Value=\"") + "Value=\"".Length);
                tmpValue = tmpValue.Remove(tmpValue.IndexOf('\"'));

                protocolElements.Add(new ProtocolElementModel
                {
                    ID = tmpID,
                    Name = tmpName,
                    Value = tmpValue
                });
            }
            #endregion FillElements
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
            string jsonFile = JsonConvert.SerializeObject(protocol, Newtonsoft.Json.Formatting.Indented);
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "JSon протокол (*.json) | *.json",
                Title = "Сохранение протокола",
                InitialDirectory = settings.DefaultProtocolPath
            };
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
        private async void ImportElementsBtn_Click(object sender, EventArgs e)
        {
            ImportForm import = new ImportForm();
            import.ShowDialog();
            if (string.IsNullOrEmpty(import.ImportBuffer))
                return;
            LoadingPictureBox.Visible = true;
            LoadingPictureBox.BringToFront();
            await Task.Run(() => OnImport(import));
            LoadingPictureBox.SendToBack();
            LoadingPictureBox.Visible = false;
        }
        private async void ImportTxtBtn_Click(object sender, EventArgs e)
        {
            ImportForm import = new ImportForm();
            import.ShowDialog();
            if (string.IsNullOrEmpty(import.ImportBuffer))
                return;
            LoadingPictureBox.Visible = true;
            LoadingPictureBox.BringToFront();
            await Task.Run(() => OnImportTxt(import));
            LoadingPictureBox.SendToBack();
            LoadingPictureBox.Visible = false;
        }
        private void OnImport(ImportForm import)
        {
            string[] bufferToImport = import.ImportBuffer.Split('\n');
            foreach (string item in bufferToImport)
            {
                if (item.Equals(string.Empty))
                    continue;
                string[] words = item.Split(' ');
                string tmpID = string.Empty;
                if (words.Length < 5 || !importTranslateCheck.Checked)
                    tmpID = "DefaultID";
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (words[i].Any(char.IsPunctuation))
                            continue;
                        tmpID += words[i] + " ";
                    }
                    tmpID = TextTranslator.TranslateToEng(tmpID);
                }
                protocolElements.Add(new ProtocolElementModel
                {
                    ID = tmpID,
                    Value = item.Replace("\r", string.Empty)
                });
            }
        }
        private void OnImportTxt(ImportForm import)
        {
            //List<string> Names = new List<string>();
            List<string> Values = new List<string>();
            string[] bufferToImport = import.ImportBuffer.Split('\n');
            foreach (var item in bufferToImport)
            {
                //if (item.Contains("Name="))
                //{
                //    string tmp = item.Remove(0, item.IndexOf("Name=\"") + "Name=\"".Length);
                //    tmp = tmp.Remove(tmp.IndexOf('\"'));
                //    Names.Add(tmp);
                //}
                if (item.Contains("Value="))
                {
                    string tmp = item.Remove(0, item.IndexOf("Value=\"") + "Value=\"".Length);
                    tmp = tmp.Remove(tmp.IndexOf('\"'));
                    Values.Add(tmp);
                }
            }
            string value = string.Empty;
            foreach (var item in Values)
            {
                value += item + "\\r\\n";
            }
            protocolElements.Add(new ProtocolElementModel
            {
                ID = "Diagnosis",
                Value = value.Remove(value.LastIndexOf("\\r\\n"))
            });
        }
        private void DefaultFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (DialogResult.OK == folder.ShowDialog())
            {
                settings.DefaultProtocolPath = folder.SelectedPath;
                SettingsLogic.SetConfig(settings, Environment.CurrentDirectory + "\\AppSettings.json");
            }
            else
                return;
        }

        #endregion menu buttons

        #region copy buttons
        private void CopyIDBtn_Click(object sender, EventArgs e) =>
            Clipboard.SetText(IDprotocolTextBox.Text.Equals(string.Empty) ? "default.protocol.ID" : IDprotocolTextBox.Text);
        private void CopyNameBtn_Click(object sender, EventArgs e) =>
            Clipboard.SetText(nameProtocolTextBox.Text.Equals(string.Empty) ? "default.protocol.Name" : nameProtocolTextBox.Text);
        private void CopyHeaderBtn_Click(object sender, EventArgs e) => Clipboard.SetText("ProtocolName");
        private void CopyConclusionBtn_Click(object sender, EventArgs e) => Clipboard.SetText("Conclusion");
        private void CopyItemIDBtn_Click(object sender, EventArgs e)
        {
            if (!idTextBox.Text.Equals(string.Empty))
                Clipboard.SetText(idTextBox.Text);
        }
        #endregion

        #region context buttons
        private void DeleteContextMenu_Click(object sender, EventArgs e)
        {
            deleteButton.PerformClick();
        }
        private void DeleteAllContext_Click(object sender, EventArgs e)
        {
            protocolElements.Clear();
        }
        private void MergeAllBtn_Click(object sender, EventArgs e)
        {
            ProtocolElementModel model = new ProtocolElementModel { ID = "Diagnosis" };
            string value = string.Empty;
            foreach (var item in protocolElements)
            {
                value += item.Name + item.Value + "\\r\\n";
            }
            model.Value = value.Remove(value.LastIndexOf("\\r\\n"));
            protocolElements.Clear();
            protocolElements.Add(model);
        }

        #endregion

        #region Drag and Drop
        private void ProtocolList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Move : DragDropEffects.None;
        }
        private void ProtocolList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1)
            {
                foreach (var item in files)
                {
                    OnOpenTxt(item, true);
                    if (mergeIfDropChk.Checked)
                        mergeAllBtn.PerformClick();
                    OnExportTxt(item, true);
                }
            }
            else
            {
                OnOpenTxt(files[0], true);
                if (mergeIfDropChk.Checked)
                    mergeAllBtn.PerformClick();
            }
        }
        #endregion

        #region Check boxes
        private void mergeIfDropChk_Click(object sender, EventArgs e)
        {
            mergeIfDropChk.Text = mergeIfDropChk.Checked ? "Объединять при перетаскивании" : "Не объединять при перетаскивании";
        }

        private void importTranslateCheck_Click(object sender, EventArgs e)
        {
            importTranslateCheck.Text = importTranslateCheck.Checked ? "Переводить при импорте" : " Не переводить при импорте";
        }
        #endregion Check boxes
    }
}

namespace ProtocolCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.createButton = new System.Windows.Forms.Button();
            this.listPanel = new System.Windows.Forms.Panel();
            this.conclusionTextBox = new System.Windows.Forms.TextBox();
            this.stack4 = new System.Windows.Forms.Panel();
            this.copyConclusionBtn = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.headerProtocolTextBox = new System.Windows.Forms.TextBox();
            this.stack3 = new System.Windows.Forms.Panel();
            this.copyHeaderBtn = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameProtocolTextBox = new System.Windows.Forms.TextBox();
            this.stack2 = new System.Windows.Forms.Panel();
            this.copyNameBtn = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IDprotocolTextBox = new System.Windows.Forms.TextBox();
            this.stack1 = new System.Windows.Forms.Panel();
            this.copyIDBtn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.protocolList = new System.Windows.Forms.ListBox();
            this.elementsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeAllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.listButtonsPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.LoadingPictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.translateIDTextBox = new System.Windows.Forms.PictureBox();
            this.copyItemIDButton = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openFromFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openFromTxtBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.importElementsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.importTxtBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultFolderBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeIfDropChk = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTxtButton = new System.Windows.Forms.Button();
            this.importTranslateCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.listPanel.SuspendLayout();
            this.stack4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyConclusionBtn)).BeginInit();
            this.stack3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyHeaderBtn)).BeginInit();
            this.stack2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyNameBtn)).BeginInit();
            this.stack1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyIDBtn)).BeginInit();
            this.elementsMenu.SuspendLayout();
            this.listButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingPictureBox)).BeginInit();
            this.itemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.translateIDTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.copyItemIDButton)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(381, 443);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(598, 28);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Сгенерировать";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.conclusionTextBox);
            this.listPanel.Controls.Add(this.stack4);
            this.listPanel.Controls.Add(this.headerProtocolTextBox);
            this.listPanel.Controls.Add(this.stack3);
            this.listPanel.Controls.Add(this.nameProtocolTextBox);
            this.listPanel.Controls.Add(this.stack2);
            this.listPanel.Controls.Add(this.IDprotocolTextBox);
            this.listPanel.Controls.Add(this.stack1);
            this.listPanel.Controls.Add(this.protocolList);
            this.listPanel.Controls.Add(this.listButtonsPanel);
            this.listPanel.Controls.Add(this.LoadingPictureBox);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.listPanel.Location = new System.Drawing.Point(0, 24);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(381, 447);
            this.listPanel.TabIndex = 9;
            // 
            // conclusionTextBox
            // 
            this.conclusionTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.conclusionTextBox.Location = new System.Drawing.Point(0, 342);
            this.conclusionTextBox.Multiline = true;
            this.conclusionTextBox.Name = "conclusionTextBox";
            this.conclusionTextBox.Size = new System.Drawing.Size(381, 97);
            this.conclusionTextBox.TabIndex = 11;
            // 
            // stack4
            // 
            this.stack4.Controls.Add(this.copyConclusionBtn);
            this.stack4.Controls.Add(this.label7);
            this.stack4.Dock = System.Windows.Forms.DockStyle.Top;
            this.stack4.Location = new System.Drawing.Point(0, 312);
            this.stack4.Name = "stack4";
            this.stack4.Size = new System.Drawing.Size(381, 30);
            this.stack4.TabIndex = 15;
            // 
            // copyConclusionBtn
            // 
            this.copyConclusionBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyConclusionBtn.Image = global::ProtocolCreator.Properties.Resources.copy;
            this.copyConclusionBtn.Location = new System.Drawing.Point(342, 0);
            this.copyConclusionBtn.Name = "copyConclusionBtn";
            this.copyConclusionBtn.Size = new System.Drawing.Size(30, 30);
            this.copyConclusionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.copyConclusionBtn.TabIndex = 6;
            this.copyConclusionBtn.TabStop = false;
            this.copyConclusionBtn.Click += new System.EventHandler(this.CopyConclusionBtn_Click);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(342, 30);
            this.label7.TabIndex = 2;
            this.label7.Text = "Заключение";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerProtocolTextBox
            // 
            this.headerProtocolTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerProtocolTextBox.Location = new System.Drawing.Point(0, 292);
            this.headerProtocolTextBox.Name = "headerProtocolTextBox";
            this.headerProtocolTextBox.Size = new System.Drawing.Size(381, 20);
            this.headerProtocolTextBox.TabIndex = 9;
            // 
            // stack3
            // 
            this.stack3.Controls.Add(this.copyHeaderBtn);
            this.stack3.Controls.Add(this.label5);
            this.stack3.Dock = System.Windows.Forms.DockStyle.Top;
            this.stack3.Location = new System.Drawing.Point(0, 262);
            this.stack3.Name = "stack3";
            this.stack3.Size = new System.Drawing.Size(381, 30);
            this.stack3.TabIndex = 14;
            // 
            // copyHeaderBtn
            // 
            this.copyHeaderBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyHeaderBtn.Image = global::ProtocolCreator.Properties.Resources.copy;
            this.copyHeaderBtn.Location = new System.Drawing.Point(342, 0);
            this.copyHeaderBtn.Name = "copyHeaderBtn";
            this.copyHeaderBtn.Size = new System.Drawing.Size(30, 30);
            this.copyHeaderBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.copyHeaderBtn.TabIndex = 5;
            this.copyHeaderBtn.TabStop = false;
            this.copyHeaderBtn.Click += new System.EventHandler(this.CopyHeaderBtn_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(342, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "Заголовок";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameProtocolTextBox
            // 
            this.nameProtocolTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameProtocolTextBox.Location = new System.Drawing.Point(0, 242);
            this.nameProtocolTextBox.Name = "nameProtocolTextBox";
            this.nameProtocolTextBox.Size = new System.Drawing.Size(381, 20);
            this.nameProtocolTextBox.TabIndex = 7;
            // 
            // stack2
            // 
            this.stack2.Controls.Add(this.copyNameBtn);
            this.stack2.Controls.Add(this.label8);
            this.stack2.Dock = System.Windows.Forms.DockStyle.Top;
            this.stack2.Location = new System.Drawing.Point(0, 212);
            this.stack2.Name = "stack2";
            this.stack2.Size = new System.Drawing.Size(381, 30);
            this.stack2.TabIndex = 13;
            // 
            // copyNameBtn
            // 
            this.copyNameBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyNameBtn.Image = global::ProtocolCreator.Properties.Resources.copy;
            this.copyNameBtn.Location = new System.Drawing.Point(342, 0);
            this.copyNameBtn.Name = "copyNameBtn";
            this.copyNameBtn.Size = new System.Drawing.Size(30, 30);
            this.copyNameBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.copyNameBtn.TabIndex = 4;
            this.copyNameBtn.TabStop = false;
            this.copyNameBtn.Click += new System.EventHandler(this.CopyNameBtn_Click);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(342, 30);
            this.label8.TabIndex = 2;
            this.label8.Text = "Название протокола";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDprotocolTextBox
            // 
            this.IDprotocolTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.IDprotocolTextBox.Location = new System.Drawing.Point(0, 192);
            this.IDprotocolTextBox.Name = "IDprotocolTextBox";
            this.IDprotocolTextBox.Size = new System.Drawing.Size(381, 20);
            this.IDprotocolTextBox.TabIndex = 5;
            // 
            // stack1
            // 
            this.stack1.Controls.Add(this.copyIDBtn);
            this.stack1.Controls.Add(this.label1);
            this.stack1.Dock = System.Windows.Forms.DockStyle.Top;
            this.stack1.Location = new System.Drawing.Point(0, 162);
            this.stack1.Name = "stack1";
            this.stack1.Size = new System.Drawing.Size(381, 30);
            this.stack1.TabIndex = 12;
            // 
            // copyIDBtn
            // 
            this.copyIDBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyIDBtn.Image = global::ProtocolCreator.Properties.Resources.copy;
            this.copyIDBtn.Location = new System.Drawing.Point(342, 0);
            this.copyIDBtn.Name = "copyIDBtn";
            this.copyIDBtn.Size = new System.Drawing.Size(30, 30);
            this.copyIDBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.copyIDBtn.TabIndex = 3;
            this.copyIDBtn.TabStop = false;
            this.copyIDBtn.Click += new System.EventHandler(this.CopyIDBtn_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "ИД протокола";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // protocolList
            // 
            this.protocolList.AllowDrop = true;
            this.protocolList.ContextMenuStrip = this.elementsMenu;
            this.protocolList.Dock = System.Windows.Forms.DockStyle.Top;
            this.protocolList.FormattingEnabled = true;
            this.protocolList.Location = new System.Drawing.Point(0, 28);
            this.protocolList.Name = "protocolList";
            this.protocolList.Size = new System.Drawing.Size(381, 134);
            this.protocolList.TabIndex = 1;
            this.protocolList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProtocolList_MouseClick);
            this.protocolList.SelectedIndexChanged += new System.EventHandler(this.ProtocolList_SelectedIndexChanged);
            this.protocolList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ProtocolList_DragDrop);
            this.protocolList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ProtocolList_DragEnter);
            this.protocolList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProtocolList_KeyDown);
            // 
            // elementsMenu
            // 
            this.elementsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteContextMenu,
            this.deleteAllContext,
            this.mergeAllBtn});
            this.elementsMenu.Name = "elementsMenu";
            this.elementsMenu.Size = new System.Drawing.Size(163, 70);
            // 
            // deleteContextMenu
            // 
            this.deleteContextMenu.Enabled = false;
            this.deleteContextMenu.Name = "deleteContextMenu";
            this.deleteContextMenu.Size = new System.Drawing.Size(162, 22);
            this.deleteContextMenu.Text = "Удалить";
            this.deleteContextMenu.Click += new System.EventHandler(this.DeleteContextMenu_Click);
            // 
            // deleteAllContext
            // 
            this.deleteAllContext.Enabled = false;
            this.deleteAllContext.Name = "deleteAllContext";
            this.deleteAllContext.Size = new System.Drawing.Size(162, 22);
            this.deleteAllContext.Text = "Удалить все";
            this.deleteAllContext.Click += new System.EventHandler(this.DeleteAllContext_Click);
            // 
            // mergeAllBtn
            // 
            this.mergeAllBtn.Enabled = false;
            this.mergeAllBtn.Name = "mergeAllBtn";
            this.mergeAllBtn.Size = new System.Drawing.Size(162, 22);
            this.mergeAllBtn.Text = "Объединить все";
            this.mergeAllBtn.Click += new System.EventHandler(this.MergeAllBtn_Click);
            // 
            // listButtonsPanel
            // 
            this.listButtonsPanel.Controls.Add(this.deleteButton);
            this.listButtonsPanel.Controls.Add(this.addButton);
            this.listButtonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.listButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.listButtonsPanel.Name = "listButtonsPanel";
            this.listButtonsPanel.Size = new System.Drawing.Size(381, 28);
            this.listButtonsPanel.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(187, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(187, 28);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.addButton.Location = new System.Drawing.Point(0, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(187, 28);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // LoadingPictureBox
            // 
            this.LoadingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoadingPictureBox.Image = global::ProtocolCreator.Properties.Resources.LoadingTransparent;
            this.LoadingPictureBox.Location = new System.Drawing.Point(0, 28);
            this.LoadingPictureBox.Name = "LoadingPictureBox";
            this.LoadingPictureBox.Size = new System.Drawing.Size(381, 134);
            this.LoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingPictureBox.TabIndex = 12;
            this.LoadingPictureBox.TabStop = false;
            this.LoadingPictureBox.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name=";
            // 
            // idTextBox
            // 
            this.idTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idTextBox.Location = new System.Drawing.Point(98, 14);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(487, 22);
            this.idTextBox.TabIndex = 0;
            this.idTextBox.TextChanged += new System.EventHandler(this.Item_TextChanged);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueTextBox.Location = new System.Drawing.Point(70, 70);
            this.valueTextBox.Multiline = true;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.valueTextBox.Size = new System.Drawing.Size(515, 229);
            this.valueTextBox.TabIndex = 2;
            this.valueTextBox.TextChanged += new System.EventHandler(this.Item_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Value=";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(70, 42);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(515, 22);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.Item_TextChanged);
            // 
            // itemPanel
            // 
            this.itemPanel.Controls.Add(this.translateIDTextBox);
            this.itemPanel.Controls.Add(this.copyItemIDButton);
            this.itemPanel.Controls.Add(this.saveButton);
            this.itemPanel.Controls.Add(this.nameTextBox);
            this.itemPanel.Controls.Add(this.label4);
            this.itemPanel.Controls.Add(this.label2);
            this.itemPanel.Controls.Add(this.valueTextBox);
            this.itemPanel.Controls.Add(this.idTextBox);
            this.itemPanel.Controls.Add(this.label3);
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemPanel.Location = new System.Drawing.Point(381, 24);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(598, 385);
            this.itemPanel.TabIndex = 10;
            // 
            // translateIDTextBox
            // 
            this.translateIDTextBox.Image = global::ProtocolCreator.Properties.Resources.translate;
            this.translateIDTextBox.Location = new System.Drawing.Point(70, 14);
            this.translateIDTextBox.Name = "translateIDTextBox";
            this.translateIDTextBox.Size = new System.Drawing.Size(22, 22);
            this.translateIDTextBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.translateIDTextBox.TabIndex = 10;
            this.translateIDTextBox.TabStop = false;
            this.translateIDTextBox.Click += new System.EventHandler(this.TranslateIDTextBox_Click);
            // 
            // copyItemIDButton
            // 
            this.copyItemIDButton.Image = global::ProtocolCreator.Properties.Resources.copy;
            this.copyItemIDButton.Location = new System.Drawing.Point(42, 14);
            this.copyItemIDButton.Name = "copyItemIDButton";
            this.copyItemIDButton.Size = new System.Drawing.Size(22, 22);
            this.copyItemIDButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.copyItemIDButton.TabIndex = 9;
            this.copyItemIDButton.TabStop = false;
            this.copyItemIDButton.Click += new System.EventHandler(this.CopyItemIDBtn_Click);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(0, 357);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(598, 28);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.importElementsBtn,
            this.importTxtBtn,
            this.defaultFolderBtn,
            this.mergeIfDropChk,
            this.importTranslateCheck});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.openFromFileButton,
            this.openFromTxtBtn,
            this.saveToFileButton});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";
            // 
            // newFileButton
            // 
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(138, 22);
            this.newFileButton.Text = "Новый";
            this.newFileButton.Click += new System.EventHandler(this.NewFileButton_Click);
            // 
            // openFromFileButton
            // 
            this.openFromFileButton.Name = "openFromFileButton";
            this.openFromFileButton.Size = new System.Drawing.Size(138, 22);
            this.openFromFileButton.Text = "Открыть";
            this.openFromFileButton.Click += new System.EventHandler(this.OpenFromFileButton_Click);
            // 
            // openFromTxtBtn
            // 
            this.openFromTxtBtn.Name = "openFromTxtBtn";
            this.openFromTxtBtn.Size = new System.Drawing.Size(138, 22);
            this.openFromTxtBtn.Text = "Открыть txt";
            this.openFromTxtBtn.Click += new System.EventHandler(this.OpenFromTxtBtn_Click);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Enabled = false;
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(138, 22);
            this.saveToFileButton.Text = "Сохранить";
            this.saveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
            // 
            // importElementsBtn
            // 
            this.importElementsBtn.Name = "importElementsBtn";
            this.importElementsBtn.Size = new System.Drawing.Size(125, 20);
            this.importElementsBtn.Text = "Импорт элементов";
            this.importElementsBtn.Click += new System.EventHandler(this.ImportElementsBtn_Click);
            // 
            // importTxtBtn
            // 
            this.importTxtBtn.Name = "importTxtBtn";
            this.importTxtBtn.Size = new System.Drawing.Size(95, 20);
            this.importTxtBtn.Text = "Импорт из txt";
            this.importTxtBtn.Click += new System.EventHandler(this.ImportTxtBtn_Click);
            // 
            // defaultFolderBtn
            // 
            this.defaultFolderBtn.Name = "defaultFolderBtn";
            this.defaultFolderBtn.Size = new System.Drawing.Size(144, 20);
            this.defaultFolderBtn.Text = "Папка для протоколов";
            this.defaultFolderBtn.Click += new System.EventHandler(this.DefaultFolderBtn_Click);
            // 
            // mergeIfDropChk
            // 
            this.mergeIfDropChk.Checked = true;
            this.mergeIfDropChk.CheckOnClick = true;
            this.mergeIfDropChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mergeIfDropChk.Name = "mergeIfDropChk";
            this.mergeIfDropChk.Size = new System.Drawing.Size(201, 20);
            this.mergeIfDropChk.Text = "Объединять при перетаскивании";
            this.mergeIfDropChk.Click += new System.EventHandler(this.mergeIfDropChk_Click);
            // 
            // exportTxtButton
            // 
            this.exportTxtButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exportTxtButton.Location = new System.Drawing.Point(381, 415);
            this.exportTxtButton.Name = "exportTxtButton";
            this.exportTxtButton.Size = new System.Drawing.Size(598, 28);
            this.exportTxtButton.TabIndex = 12;
            this.exportTxtButton.Text = "Экспорт в txt";
            this.exportTxtButton.UseVisualStyleBackColor = true;
            this.exportTxtButton.Click += new System.EventHandler(this.exportTxtButton_Click);
            // 
            // importTranslateCheck
            // 
            this.importTranslateCheck.Checked = true;
            this.importTranslateCheck.CheckOnClick = true;
            this.importTranslateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.importTranslateCheck.Name = "importTranslateCheck";
            this.importTranslateCheck.Size = new System.Drawing.Size(159, 20);
            this.importTranslateCheck.Text = "Переводить при импорте";
            this.importTranslateCheck.Click += new System.EventHandler(this.importTranslateCheck_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(979, 471);
            this.Controls.Add(this.exportTxtButton);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creator";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
            this.stack4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.copyConclusionBtn)).EndInit();
            this.stack3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.copyHeaderBtn)).EndInit();
            this.stack2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.copyNameBtn)).EndInit();
            this.stack1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.copyIDBtn)).EndInit();
            this.elementsMenu.ResumeLayout(false);
            this.listButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingPictureBox)).EndInit();
            this.itemPanel.ResumeLayout(false);
            this.itemPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.translateIDTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.copyItemIDButton)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.ListBox protocolList;
        private System.Windows.Forms.Panel listButtonsPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newFileButton;
        private System.Windows.Forms.ToolStripMenuItem openFromFileButton;
        private System.Windows.Forms.ToolStripMenuItem saveToFileButton;
        private System.Windows.Forms.TextBox conclusionTextBox;
        private System.Windows.Forms.TextBox nameProtocolTextBox;
        private System.Windows.Forms.TextBox IDprotocolTextBox;
        private System.Windows.Forms.TextBox headerProtocolTextBox;
        private System.Windows.Forms.Panel stack4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel stack3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel stack2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel stack1;
        private System.Windows.Forms.PictureBox copyIDBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox copyConclusionBtn;
        private System.Windows.Forms.PictureBox copyHeaderBtn;
        private System.Windows.Forms.PictureBox copyNameBtn;
        private System.Windows.Forms.PictureBox copyItemIDButton;
        private System.Windows.Forms.PictureBox translateIDTextBox;
        private System.Windows.Forms.ToolStripMenuItem importElementsBtn;
        private System.Windows.Forms.PictureBox LoadingPictureBox;
        private System.Windows.Forms.ToolStripMenuItem importTxtBtn;
        private System.Windows.Forms.ToolStripMenuItem openFromTxtBtn;
        private System.Windows.Forms.ToolStripMenuItem defaultFolderBtn;
        private System.Windows.Forms.ContextMenuStrip elementsMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteAllContext;
        private System.Windows.Forms.ToolStripMenuItem mergeAllBtn;
        private System.Windows.Forms.Button exportTxtButton;
        private System.Windows.Forms.ToolStripMenuItem mergeIfDropChk;
        private System.Windows.Forms.ToolStripMenuItem importTranslateCheck;
    }
}


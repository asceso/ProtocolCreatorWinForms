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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.createButton = new System.Windows.Forms.Button();
            this.listPanel = new System.Windows.Forms.Panel();
            this.protocolList = new System.Windows.Forms.ListBox();
            this.listButtonsPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openFromFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.listPanel.SuspendLayout();
            this.listButtonsPanel.SuspendLayout();
            this.itemPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(0, 401);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(569, 28);
            this.createButton.TabIndex = 3;
            this.createButton.Text = "Сгенерировать";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.protocolList);
            this.listPanel.Controls.Add(this.listButtonsPanel);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.listPanel.Location = new System.Drawing.Point(0, 24);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(569, 169);
            this.listPanel.TabIndex = 9;
            // 
            // protocolList
            // 
            this.protocolList.FormattingEnabled = true;
            this.protocolList.Location = new System.Drawing.Point(3, 32);
            this.protocolList.Name = "protocolList";
            this.protocolList.Size = new System.Drawing.Size(563, 134);
            this.protocolList.TabIndex = 1;
            this.protocolList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProtocolList_MouseClick);
            this.protocolList.SelectedIndexChanged += new System.EventHandler(this.ProtocolList_SelectedIndexChanged);
            // 
            // listButtonsPanel
            // 
            this.listButtonsPanel.Controls.Add(this.deleteButton);
            this.listButtonsPanel.Controls.Add(this.addButton);
            this.listButtonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.listButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.listButtonsPanel.Name = "listButtonsPanel";
            this.listButtonsPanel.Size = new System.Drawing.Size(569, 28);
            this.listButtonsPanel.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(286, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(280, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(280, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name=";
            // 
            // idTextBox
            // 
            this.idTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idTextBox.Location = new System.Drawing.Point(42, 10);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(515, 24);
            this.idTextBox.TabIndex = 0;
            this.idTextBox.TextChanged += new System.EventHandler(this.Item_TextChanged);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueTextBox.Location = new System.Drawing.Point(59, 62);
            this.valueTextBox.Multiline = true;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(498, 138);
            this.valueTextBox.TabIndex = 2;
            this.valueTextBox.TextChanged += new System.EventHandler(this.Item_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Value=";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(59, 36);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(498, 24);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.Item_TextChanged);
            // 
            // itemPanel
            // 
            this.itemPanel.Controls.Add(this.saveButton);
            this.itemPanel.Controls.Add(this.nameTextBox);
            this.itemPanel.Controls.Add(this.label4);
            this.itemPanel.Controls.Add(this.label2);
            this.itemPanel.Controls.Add(this.valueTextBox);
            this.itemPanel.Controls.Add(this.idTextBox);
            this.itemPanel.Controls.Add(this.label3);
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel.Location = new System.Drawing.Point(0, 193);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(569, 208);
            this.itemPanel.TabIndex = 10;
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(0, 185);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(569, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(569, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.openFromFileButton,
            this.saveToFileButton});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";
            // 
            // newFileButton
            // 
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(133, 22);
            this.newFileButton.Text = "Новый";
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // openFromFileButton
            // 
            this.openFromFileButton.Name = "openFromFileButton";
            this.openFromFileButton.Size = new System.Drawing.Size(133, 22);
            this.openFromFileButton.Text = "Открыть";
            this.openFromFileButton.Click += new System.EventHandler(this.openFromFileButton_Click);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Enabled = false;
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(133, 22);
            this.saveToFileButton.Text = "Сохранить";
            this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 429);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creator";
            this.listPanel.ResumeLayout(false);
            this.listButtonsPanel.ResumeLayout(false);
            this.itemPanel.ResumeLayout(false);
            this.itemPanel.PerformLayout();
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
    }
}


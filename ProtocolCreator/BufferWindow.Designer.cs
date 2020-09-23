namespace ProtocolCreator
{
    partial class BufferWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bufferTextBox = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.exportDefaultButton = new System.Windows.Forms.Button();
            this.idCollectionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bufferTextBox
            // 
            this.bufferTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.bufferTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bufferTextBox.Location = new System.Drawing.Point(0, 0);
            this.bufferTextBox.Multiline = true;
            this.bufferTextBox.Name = "bufferTextBox";
            this.bufferTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bufferTextBox.Size = new System.Drawing.Size(1253, 271);
            this.bufferTextBox.TabIndex = 0;
            // 
            // copyButton
            // 
            this.copyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.copyButton.Location = new System.Drawing.Point(0, 459);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(1253, 23);
            this.copyButton.TabIndex = 1;
            this.copyButton.Text = "Скопировать в буфер";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // exportDefaultButton
            // 
            this.exportDefaultButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.exportDefaultButton.Location = new System.Drawing.Point(0, 436);
            this.exportDefaultButton.Name = "exportDefaultButton";
            this.exportDefaultButton.Size = new System.Drawing.Size(1253, 23);
            this.exportDefaultButton.TabIndex = 2;
            this.exportDefaultButton.Text = "Сохранить с именем протокола";
            this.exportDefaultButton.UseVisualStyleBackColor = true;
            this.exportDefaultButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // idCollectionTextBox
            // 
            this.idCollectionTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.idCollectionTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idCollectionTextBox.Location = new System.Drawing.Point(0, 271);
            this.idCollectionTextBox.Multiline = true;
            this.idCollectionTextBox.Name = "idCollectionTextBox";
            this.idCollectionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.idCollectionTextBox.Size = new System.Drawing.Size(1253, 165);
            this.idCollectionTextBox.TabIndex = 3;
            // 
            // BufferWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 488);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.exportDefaultButton);
            this.Controls.Add(this.idCollectionTextBox);
            this.Controls.Add(this.bufferTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BufferWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BufferWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bufferTextBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button exportDefaultButton;
        private System.Windows.Forms.TextBox idCollectionTextBox;
    }
}
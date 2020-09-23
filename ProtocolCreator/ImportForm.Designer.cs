namespace ProtocolCreator
{
    partial class ImportForm
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
            this.importBuffer = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // importBuffer
            // 
            this.importBuffer.Dock = System.Windows.Forms.DockStyle.Top;
            this.importBuffer.Location = new System.Drawing.Point(0, 0);
            this.importBuffer.Multiline = true;
            this.importBuffer.Name = "importBuffer";
            this.importBuffer.Size = new System.Drawing.Size(470, 365);
            this.importBuffer.TabIndex = 0;
            this.importBuffer.TextChanged += new System.EventHandler(this.ImportBuffer_TextChanged);
            // 
            // importButton
            // 
            this.importButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(0, 365);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(470, 27);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Импорт";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 392);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.importBuffer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Импорт элементов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox importBuffer;
        private System.Windows.Forms.Button importButton;
    }
}
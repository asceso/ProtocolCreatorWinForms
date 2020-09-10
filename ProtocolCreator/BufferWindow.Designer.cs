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
            this.SuspendLayout();
            // 
            // bufferTextBox
            // 
            this.bufferTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bufferTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bufferTextBox.Location = new System.Drawing.Point(0, 0);
            this.bufferTextBox.Multiline = true;
            this.bufferTextBox.Name = "bufferTextBox";
            this.bufferTextBox.Size = new System.Drawing.Size(504, 379);
            this.bufferTextBox.TabIndex = 0;
            // 
            // copyButton
            // 
            this.copyButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.copyButton.Location = new System.Drawing.Point(0, 379);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(504, 23);
            this.copyButton.TabIndex = 1;
            this.copyButton.Text = "Скопировать в буфер";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // BufferWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 402);
            this.Controls.Add(this.bufferTextBox);
            this.Controls.Add(this.copyButton);
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
    }
}
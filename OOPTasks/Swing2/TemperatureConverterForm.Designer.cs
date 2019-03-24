namespace Swing2
{
    partial class TemperatureConverterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureConverterForm));
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.outputGroupBox = new System.Windows.Forms.GroupBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.inputSymbolLabel = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.outputPanel.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Location = new System.Drawing.Point(5, 8);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(168, 35);
            this.inputGroupBox.TabIndex = 0;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Тип градусной шкалы";
            // 
            // outputGroupBox
            // 
            this.outputGroupBox.Location = new System.Drawing.Point(179, 8);
            this.outputGroupBox.Name = "outputGroupBox";
            this.outputGroupBox.Size = new System.Drawing.Size(168, 35);
            this.outputGroupBox.TabIndex = 1;
            this.outputGroupBox.TabStop = false;
            this.outputGroupBox.Text = "После конвертации";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(3, 3);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(90, 22);
            this.inputTextBox.TabIndex = 2;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.outputLabel.Location = new System.Drawing.Point(33, 6);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(46, 17);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "label1";
            // 
            // outputPanel
            // 
            this.outputPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputPanel.Controls.Add(this.outputLabel);
            this.outputPanel.Location = new System.Drawing.Point(179, 181);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(168, 30);
            this.outputPanel.TabIndex = 4;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.inputSymbolLabel);
            this.inputPanel.Controls.Add(this.inputTextBox);
            this.inputPanel.Location = new System.Drawing.Point(5, 181);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(168, 30);
            this.inputPanel.TabIndex = 5;
            // 
            // inputSymbolLabel
            // 
            this.inputSymbolLabel.AutoSize = true;
            this.inputSymbolLabel.Location = new System.Drawing.Point(101, 6);
            this.inputSymbolLabel.Name = "inputSymbolLabel";
            this.inputSymbolLabel.Size = new System.Drawing.Size(46, 17);
            this.inputSymbolLabel.TabIndex = 3;
            this.inputSymbolLabel.Text = "label2";
            // 
            // convertButton
            // 
            this.convertButton.ForeColor = System.Drawing.Color.DarkRed;
            this.convertButton.Location = new System.Drawing.Point(4, 219);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(343, 28);
            this.convertButton.TabIndex = 6;
            this.convertButton.Text = "к о н в е р т и р о в а т ь";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // TemperatureConverterForm
            // 
            this.AcceptButton = this.convertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 486);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.outputGroupBox);
            this.Controls.Add(this.inputGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemperatureConverterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер температур";
            this.Load += new System.EventHandler(this.TemperatureConverterForm_Load);
            this.outputPanel.ResumeLayout(false);
            this.outputPanel.PerformLayout();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.GroupBox outputGroupBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label inputSymbolLabel;
    }
}


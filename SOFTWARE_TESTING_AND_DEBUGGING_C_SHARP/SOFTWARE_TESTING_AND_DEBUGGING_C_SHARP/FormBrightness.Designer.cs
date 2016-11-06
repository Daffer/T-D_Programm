namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    partial class FormBrightness
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.MaxValueLabel = new System.Windows.Forms.Label();
            this.MinValueLabel = new System.Windows.Forms.Label();
            this.BrightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.ContrastTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(157, 152);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(76, 23);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "Отменить";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(85, 152);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(2);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(68, 23);
            this.SubmitButton.TabIndex = 11;
            this.SubmitButton.Text = "Принять";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // MaxValueLabel
            // 
            this.MaxValueLabel.AutoSize = true;
            this.MaxValueLabel.Location = new System.Drawing.Point(272, 52);
            this.MaxValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MaxValueLabel.Name = "MaxValueLabel";
            this.MaxValueLabel.Size = new System.Drawing.Size(25, 13);
            this.MaxValueLabel.TabIndex = 10;
            this.MaxValueLabel.Text = "255";
            // 
            // MinValueLabel
            // 
            this.MinValueLabel.AutoSize = true;
            this.MinValueLabel.Location = new System.Drawing.Point(8, 52);
            this.MinValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MinValueLabel.Name = "MinValueLabel";
            this.MinValueLabel.Size = new System.Drawing.Size(13, 13);
            this.MinValueLabel.TabIndex = 9;
            this.MinValueLabel.Text = "0";
            // 
            // BrightnessTrackBar
            // 
            this.BrightnessTrackBar.Location = new System.Drawing.Point(11, 18);
            this.BrightnessTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this.BrightnessTrackBar.Maximum = 255;
            this.BrightnessTrackBar.Name = "BrightnessTrackBar";
            this.BrightnessTrackBar.Size = new System.Drawing.Size(286, 45);
            this.BrightnessTrackBar.TabIndex = 8;
            this.BrightnessTrackBar.Value = 128;
            // 
            // ContrastTrackBar
            // 
            this.ContrastTrackBar.Location = new System.Drawing.Point(11, 86);
            this.ContrastTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this.ContrastTrackBar.Maximum = 255;
            this.ContrastTrackBar.Name = "ContrastTrackBar";
            this.ContrastTrackBar.Size = new System.Drawing.Size(286, 45);
            this.ContrastTrackBar.TabIndex = 7;
            this.ContrastTrackBar.Value = 127;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Яркость";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Контрастность";
            // 
            // InfoLabel
            // 
            this.InfoLabel.Location = new System.Drawing.Point(11, 189);
            this.InfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InfoLabel.MaximumSize = new System.Drawing.Size(375, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(286, 0);
            this.InfoLabel.TabIndex = 15;
            this.InfoLabel.Text = "Разница между текущим положением ползунка и получившимся дает величину изменения " +
    "яркости/контрастности";
            // 
            // FormBrightness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 206);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.MaxValueLabel);
            this.Controls.Add(this.MinValueLabel);
            this.Controls.Add(this.BrightnessTrackBar);
            this.Controls.Add(this.ContrastTrackBar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBrightness";
            this.Text = "FormBrightness";
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label MaxValueLabel;
        private System.Windows.Forms.Label MinValueLabel;
        private System.Windows.Forms.TrackBar BrightnessTrackBar;
        private System.Windows.Forms.TrackBar ContrastTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label InfoLabel;
    }
}
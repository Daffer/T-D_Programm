namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    partial class FormBinarization
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
            this.LowerBorderTrackBar = new System.Windows.Forms.TrackBar();
            this.UpperBorderTrackBar = new System.Windows.Forms.TrackBar();
            this.MinValueLabel = new System.Windows.Forms.Label();
            this.MaxValueLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AutoBinarizationButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LowerBorderTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperBorderTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // LowerBorderTrackBar
            // 
            this.LowerBorderTrackBar.Location = new System.Drawing.Point(17, 71);
            this.LowerBorderTrackBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LowerBorderTrackBar.Maximum = 255;
            this.LowerBorderTrackBar.Name = "LowerBorderTrackBar";
            this.LowerBorderTrackBar.Size = new System.Drawing.Size(286, 45);
            this.LowerBorderTrackBar.TabIndex = 0;
            this.LowerBorderTrackBar.Value = 127;
            // 
            // UpperBorderTrackBar
            // 
            this.UpperBorderTrackBar.Location = new System.Drawing.Point(17, 11);
            this.UpperBorderTrackBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UpperBorderTrackBar.Maximum = 255;
            this.UpperBorderTrackBar.Name = "UpperBorderTrackBar";
            this.UpperBorderTrackBar.Size = new System.Drawing.Size(286, 45);
            this.UpperBorderTrackBar.TabIndex = 1;
            this.UpperBorderTrackBar.Value = 128;
            this.UpperBorderTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UpperBorderTrackBar_MouseUp);
            // 
            // MinValueLabel
            // 
            this.MinValueLabel.AutoSize = true;
            this.MinValueLabel.Location = new System.Drawing.Point(14, 54);
            this.MinValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MinValueLabel.Name = "MinValueLabel";
            this.MinValueLabel.Size = new System.Drawing.Size(13, 13);
            this.MinValueLabel.TabIndex = 2;
            this.MinValueLabel.Text = "0";
            // 
            // MaxValueLabel
            // 
            this.MaxValueLabel.AutoSize = true;
            this.MaxValueLabel.Location = new System.Drawing.Point(278, 54);
            this.MaxValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MaxValueLabel.Name = "MaxValueLabel";
            this.MaxValueLabel.Size = new System.Drawing.Size(25, 13);
            this.MaxValueLabel.TabIndex = 3;
            this.MaxValueLabel.Text = "255";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(11, 166);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(68, 25);
            this.SubmitButton.TabIndex = 4;
            this.SubmitButton.Text = "Принять";
            this.SubmitButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(227, 166);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(76, 25);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отменить";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // AutoBinarizationButton
            // 
            this.AutoBinarizationButton.Location = new System.Drawing.Point(11, 120);
            this.AutoBinarizationButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AutoBinarizationButton.Name = "AutoBinarizationButton";
            this.AutoBinarizationButton.Size = new System.Drawing.Size(292, 28);
            this.AutoBinarizationButton.TabIndex = 6;
            this.AutoBinarizationButton.Text = "Автоматическая бинаризация";
            this.AutoBinarizationButton.UseVisualStyleBackColor = true;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Location = new System.Drawing.Point(11, 204);
            this.InfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InfoLabel.MaximumSize = new System.Drawing.Size(375, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(292, 70);
            this.InfoLabel.TabIndex = 16;
            this.InfoLabel.Text = "Здесь ползунки - верхний означает какой верхний порог бинаризации, нижний - нижни" +
    "й. Все, что внутри жиапазона бинаризуется черным.";
            // 
            // FormBinarization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 283);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.AutoBinarizationButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.MaxValueLabel);
            this.Controls.Add(this.MinValueLabel);
            this.Controls.Add(this.UpperBorderTrackBar);
            this.Controls.Add(this.LowerBorderTrackBar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormBinarization";
            this.Text = "FormBinarization";
            ((System.ComponentModel.ISupportInitialize)(this.LowerBorderTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperBorderTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar LowerBorderTrackBar;
        private System.Windows.Forms.TrackBar UpperBorderTrackBar;
        private System.Windows.Forms.Label MinValueLabel;
        private System.Windows.Forms.Label MaxValueLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AutoBinarizationButton;
        private System.Windows.Forms.Label InfoLabel;
    }
}
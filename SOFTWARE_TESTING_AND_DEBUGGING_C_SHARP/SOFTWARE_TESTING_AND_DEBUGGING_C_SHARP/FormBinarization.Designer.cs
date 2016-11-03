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
            this.trbLowerBorder = new System.Windows.Forms.TrackBar();
            this.trbUpperBorder = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAutoBinarization = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbLowerBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbUpperBorder)).BeginInit();
            this.SuspendLayout();
            // 
            // trbLowerBorder
            // 
            this.trbLowerBorder.Location = new System.Drawing.Point(62, 87);
            this.trbLowerBorder.Maximum = 255;
            this.trbLowerBorder.Name = "trbLowerBorder";
            this.trbLowerBorder.Size = new System.Drawing.Size(382, 56);
            this.trbLowerBorder.TabIndex = 0;
            this.trbLowerBorder.Value = 127;
            // 
            // trbUpperBorder
            // 
            this.trbUpperBorder.Location = new System.Drawing.Point(62, 25);
            this.trbUpperBorder.Maximum = 255;
            this.trbUpperBorder.Name = "trbUpperBorder";
            this.trbUpperBorder.Size = new System.Drawing.Size(382, 56);
            this.trbUpperBorder.TabIndex = 1;
            this.trbUpperBorder.Value = 128;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "255";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(294, 149);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(91, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Принять";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(391, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAutoBinarization
            // 
            this.btnAutoBinarization.Location = new System.Drawing.Point(25, 149);
            this.btnAutoBinarization.Name = "btnAutoBinarization";
            this.btnAutoBinarization.Size = new System.Drawing.Size(231, 23);
            this.btnAutoBinarization.TabIndex = 6;
            this.btnAutoBinarization.Text = "Автоматическая бинаризация";
            this.btnAutoBinarization.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 196);
            this.label5.MaximumSize = new System.Drawing.Size(500, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(483, 34);
            this.label5.TabIndex = 16;
            this.label5.Text = "Здесь ползунки - верхний означает какой верхний порог бинаризации, нижний - нижни" +
    "й. Все, что внутри жиапазона бинаризуется черным.";
            // 
            // FormBinarization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 285);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAutoBinarization);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbUpperBorder);
            this.Controls.Add(this.trbLowerBorder);
            this.Name = "FormBinarization";
            this.Text = "FormBinarization";
            ((System.ComponentModel.ISupportInitialize)(this.trbLowerBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbUpperBorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trbLowerBorder;
        private System.Windows.Forms.TrackBar trbUpperBorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAutoBinarization;
        private System.Windows.Forms.Label label5;
    }
}
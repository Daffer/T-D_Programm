namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    partial class FormParticleInfo
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
            this.tblParticleInfo = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblParticleInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tblParticleInfo
            // 
            this.tblParticleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblParticleInfo.Location = new System.Drawing.Point(12, 12);
            this.tblParticleInfo.Name = "tblParticleInfo";
            this.tblParticleInfo.RowTemplate.Height = 24;
            this.tblParticleInfo.Size = new System.Drawing.Size(445, 355);
            this.tblParticleInfo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 383);
            this.label5.MaximumSize = new System.Drawing.Size(500, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(489, 51);
            this.label5.TabIndex = 16;
            this.label5.Text = "Сведения об одной частице, должна показываться при нажатой кнопке \"Инф-ция о част" +
    "ице\" при нажатии на место активного документа с частицей. Если там нет частицы -" +
    " сообщение об ошибке";
            // 
            // FormParticleInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 440);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tblParticleInfo);
            this.Name = "FormParticleInfo";
            this.Text = "FormParticleInfo";
            ((System.ComponentModel.ISupportInitialize)(this.tblParticleInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblParticleInfo;
        private System.Windows.Forms.Label label5;
    }
}
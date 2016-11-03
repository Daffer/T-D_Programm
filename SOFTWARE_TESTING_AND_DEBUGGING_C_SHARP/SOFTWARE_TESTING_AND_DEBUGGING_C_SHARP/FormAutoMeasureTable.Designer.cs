namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    partial class FormAutoMeasureTable
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
            this.tblParticlesInfo = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblParticlesInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tblParticlesInfo
            // 
            this.tblParticlesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblParticlesInfo.Location = new System.Drawing.Point(12, 12);
            this.tblParticlesInfo.Name = "tblParticlesInfo";
            this.tblParticlesInfo.RowTemplate.Height = 24;
            this.tblParticlesInfo.Size = new System.Drawing.Size(790, 355);
            this.tblParticlesInfo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 378);
            this.label5.MaximumSize = new System.Drawing.Size(500, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(468, 34);
            this.label5.TabIndex = 16;
            this.label5.Text = "Полные сведения о всех частицах на активном изображении. Можно добавить кнопку им" +
    "порта в Excel";
            // 
            // FormAutoMeasureTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 421);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tblParticlesInfo);
            this.Name = "FormAutoMeasureTable";
            this.Text = "FormAutoMeasureTable";
            ((System.ComponentModel.ISupportInitialize)(this.tblParticlesInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblParticlesInfo;
        private System.Windows.Forms.Label label5;
    }
}
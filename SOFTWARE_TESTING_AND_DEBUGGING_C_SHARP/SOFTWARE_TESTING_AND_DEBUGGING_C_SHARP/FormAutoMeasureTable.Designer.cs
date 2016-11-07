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
            this.label5 = new System.Windows.Forms.Label();
            this.ParticlesInfoDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ParticlesInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 307);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.MaximumSize = new System.Drawing.Size(375, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(363, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "Полные сведения о всех частицах на активном изображении. Можно добавить кнопку им" +
    "порта в Excel";
            // 
            // ParticlesInfoDataGridView
            // 
            this.ParticlesInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParticlesInfoDataGridView.Location = new System.Drawing.Point(9, 10);
            this.ParticlesInfoDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.ParticlesInfoDataGridView.Name = "ParticlesInfoDataGridView";
            this.ParticlesInfoDataGridView.RowTemplate.Height = 24;
            this.ParticlesInfoDataGridView.Size = new System.Drawing.Size(592, 288);
            this.ParticlesInfoDataGridView.TabIndex = 1;
            // 
            // FormAutoMeasureTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 342);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ParticlesInfoDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAutoMeasureTable";
            this.Text = "FormAutoMeasureTable";
            ((System.ComponentModel.ISupportInitialize)(this.ParticlesInfoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView ParticlesInfoDataGridView;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    public partial class FormAutoMeasureTable : Form
    {
        public FormAutoMeasureTable(MainForm referencemain, ProgramImage referenceimage, Calculater referencecalc, int index)
        {
            InitializeComponent();
            ReferenceToMain = referencemain;
            ReferenceToProgramImage = referenceimage;
            ReferenceToCalculater = referencecalc;
            Index = index;
            InitDataGridView();
            InitInformation();
        }

        private void InitDataGridView()
        {
            this.ParticlesInfoDataGridView.ColumnCount = 9;
            string[] headers = new string[] {"№","Периметр","Площадь","Длина","Ширина","Диаметр по ГОСТ","Диаметр","Гладкость","Форм-Фактор"};
            for (int I = 0; I < headers.Length; I++)
            {
                this.ParticlesInfoDataGridView.Columns[I].HeaderText = headers[I];
            }
            return;
        }

        private void InitInformation()
        {
            ReferenceToCalculater.AllCalculations(ref Particles, Index);
            this.ParticlesInfoDataGridView.RowCount = Particles.Length;
            double[] content;
            for (int I = 0; I < Particles.Length; I++)
            {
                this.ParticlesInfoDataGridView[0, I].Value = I + 1;
                content = new double[] {Particles[I].Perimetr, Particles[I].Square, Particles[I].Length,
                    Particles[I].Width, Particles[I].DiameterGost, Particles[I].Diameter, Particles[I].Smoothness,
                    Particles[I].FormFactor};
                for (int J = 0; J < content.Length; J++)
                {
                    this.ParticlesInfoDataGridView[J+1,I].Value = content[J];
                }
            }
        }
        private MainForm ReferenceToMain;
        private ProgramImage ReferenceToProgramImage;
        private Calculater ReferenceToCalculater;
        private Particle[] Particles;
        private int Index;

        private void SaveToExcelButton_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}

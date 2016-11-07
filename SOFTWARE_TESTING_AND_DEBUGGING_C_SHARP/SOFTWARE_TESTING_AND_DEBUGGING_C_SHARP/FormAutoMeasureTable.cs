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
        }

        private void InitDataGridView()
        {
            this.ParticlesInfoDataGridView.ColumnCount = 9;
            string[] headers = new string[] {"№","Периметр","Площадь","Длина","Ширина","Диаметр по ГОСТ","Диаметр","Гладкость","Форм-Фактор"};
            for (int I = 0; I < headers.Length; I++)
            {
                this.ParticlesInfoDataGridView[I, 0].Value = headers[I];
            }
            return;
        }

        private void InitInformation()
        {
            
        }
        private MainForm ReferenceToMain;
        private ProgramImage ReferenceToProgramImage;
        private Calculater ReferenceToCalculater;
        private Particle[] Particles;
        private int Index;
    }
}

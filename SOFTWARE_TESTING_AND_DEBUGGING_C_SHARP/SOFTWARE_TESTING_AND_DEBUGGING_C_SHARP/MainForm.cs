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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BrightnessNContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBrightness setting = new FormBrightness(Images,this);
            setting.Show();
            setting.Focus();
            return;
        }
        private ProgramImage Images = new ProgramImage();
        public int IndexActiviteForm
        {
            get { return IndexActiviteFormImage; }
            set { IndexActiviteFormImage = value; }
        }
        private int IndexActiviteFormImage = 0;

        private void NewImageForVideoCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog system = new OpenFileDialog();
            system.ShowDialog();
            string result = system.FileName;
            Bitmap newimage = new Bitmap(result);
            Images.AddNewImage(newimage);
            return;
        }

        private void BinarizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBinarization setting = new FormBinarization(this, this.Images);
            setting.Show();
            setting.Focus();
        }
    }
}

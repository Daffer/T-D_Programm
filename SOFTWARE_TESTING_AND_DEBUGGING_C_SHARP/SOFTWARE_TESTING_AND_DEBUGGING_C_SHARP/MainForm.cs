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
            FormBrightness setting = new FormBrightness(Images);
            setting.Show();
            setting.Focus();
            return;
        }

        private ProgramImage Images = new ProgramImage();
    }
}

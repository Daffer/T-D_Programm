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
    public partial class FormBinarization : Form
    {
        public FormBinarization(MainForm referencetomain, ProgramImage referencetoprogramimage)
        {
            InitializeComponent();
            ReferenceToMainForm = referencetomain;
            ReferenceToProgramImage = referencetoprogramimage;
        }

        private MainForm ReferenceToMainForm;
        private ProgramImage ReferenceToProgramImage;
        private void UpperBorderTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            return;
        }

        private void AutoBinarizationButton_Click(object sender, EventArgs e)
        {
            int activeimage = ReferenceToMainForm.IndexActiviteForm;
            int error = ReferenceToProgramImage.MethodOtsu(activeimage);
            if (error == 0)
            {
                int number = ReferenceToProgramImage.GetCountImages();
                Bitmap referencetomap = ReferenceToProgramImage.GetLastBitmap();
                FormImage result = new FormImage(number, ReferenceToMainForm, referencetomap);
                result.Show();
                result.Focus();
                this.Dispose();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            return;
        }
    }
}

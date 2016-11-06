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
    public partial class FormBrightness : Form
    {
        public FormBrightness(ProgramImage reference_to_ProgrammImage, MainForm mainmodule)
        {
            InitializeComponent();
            ReferenceProgrammImage = reference_to_ProgrammImage;
            ReferenceToMainForm = mainmodule;
            return;
        }

        private ProgramImage ReferenceProgrammImage;
        private MainForm ReferenceToMainForm;

        private void BrightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            return;
        }        

        private void ContrastTrackBar_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void ContrastTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            int currentvalue = this.ContrastTrackBar.Value;
            int activeimage = ReferenceToMainForm.IndexActiviteForm;
            int error = ReferenceProgrammImage.Contrast(activeimage, currentvalue);
            if (error == 0)
            {
                int number = ReferenceProgrammImage.GetCountImages();
                Bitmap referencetomap = ReferenceProgrammImage.GetLastBitmap();
                FormImage result = new FormImage(number, ReferenceToMainForm, referencetomap);
                result.Show();
                result.Focus();
            }
            return;
        }

        private void BrightnessTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            int currentvalue = this.ContrastTrackBar.Value;
            int activeimage = ReferenceToMainForm.IndexActiviteForm;
            int error = ReferenceProgrammImage.Brightness(activeimage, currentvalue);
            if (error == 0)
            {
                int number = ReferenceProgrammImage.GetCountImages();
                Bitmap referencetomap = ReferenceProgrammImage.GetLastBitmap();
                FormImage result = new FormImage(number, ReferenceToMainForm, referencetomap);
                result.Show();
                result.Focus();
            }
        }
    }
}

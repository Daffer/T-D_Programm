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
    public partial class FormImage : Form
    {
        public FormImage(int index, MainForm reference, Bitmap currentmap)
        {
            InitializeComponent();
            IndexToList = index;
            ReferenceToMainForm = reference;
            Rectangle rec = new Rectangle(0, 0, currentmap.Width, currentmap.Height);
            this.PictureBox.DrawToBitmap(currentmap, rec);
        }
        private int IndexToList = 0;
        private MainForm ReferenceToMainForm;

        private void FormImage_Click(object sender, EventArgs e)
        {
            ReferenceToMainForm.IndexActiviteForm = IndexToList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void toolStripFileOpen_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void toolStripFileExit_Click(object sender, EventArgs e)
        {
            // closes the app
            this.Close();
        }

        private void toolStripFileNew_Click(object sender, EventArgs e)
        {
            // create an image of the desired size
            var bitmap = new Bitmap(400, 300);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                // specify the desired quality of the render and text, if you wish
                //graphics.CompositingQuality = CompositingQuality.HighQuality;
                //graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                // From: https://stackoverflow.com/questions/61513832/how-to-edit-image-in-c-sharp;

                // set background color
                graphics.Clear(Color.White);
            }

            pictureBox1.Image = bitmap;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    class LayerImage
    {
        protected Bitmap LayerBitmap;

        public LayerImage()
        {

        }

        private void PlainColourChoose(PictureBox targetPictureBox, ColorDialog colorDialog)
        {
            // Show the color dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // create an image of the desired size
                var bgBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);

                using (var graphics = Graphics.FromImage(bgBitmap))
                {
                    // set background color
                    graphics.Clear(colorDialog.Color);
                }

                // Updates the plain colour preview box
                targetPictureBox.Image = bgBitmap;

                // Update layer image
                this.LayerBitmap = bgBitmap;
            }
        }

    }
}

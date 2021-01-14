using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public class LayerImage
    {
        public Bitmap LayerBitmap;
        public int LayerHeight;
        protected CombinedLayers TargetCombinedLayers;


        public LayerImage(int layerHeight, CombinedLayers targetCombinedLayers)
        {
            this.LayerHeight = layerHeight;
            this.TargetCombinedLayers = targetCombinedLayers;

            // Initialise with empty bitmap
            this.LayerBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);
        }




        protected void ClearLayer()
        {
            this.LayerBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);
            this.TargetCombinedLayers.ShowCombinedLayers();
        }








    }
}

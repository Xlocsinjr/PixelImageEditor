using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    // This class defines the basics of a layer in the editor. 
    public abstract class LayerImage
    {
        public Bitmap LayerBitmap;
        public int LayerHeight;
        public CombinedLayers TargetCombinedLayers;

        // CONTSTRUCTOR. sets layer height and to which CombinedLayers this layer belongs.
        // Also initialises the layers image as an empty bitmap.
        public LayerImage(int layerHeight)
        {
            this.LayerHeight = layerHeight;

            // Initialise with empty bitmap
            this.LayerBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);
        }


        // Clears the layer with an empty bitmap
        // and clears/resets all layer options to default
        public void ClearLayer()
        {
            this.LayerBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);
            this.TargetCombinedLayers.ShowCombinedLayers();
            this.ClearOptions();
        }

        public abstract void ClearOptions();
        // declared. To be overwritten in child classes.

        public abstract void AddControls();
        // declared. To be overwritten in child classes.





    }
}

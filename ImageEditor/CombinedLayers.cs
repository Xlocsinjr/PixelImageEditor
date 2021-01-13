using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    class CombinedLayers
    {
        Bitmap CombinedBitmap;
        List<Bitmap> LayersList;
        List<Layers> LayersIndeces; // Declare list of the enums so the indeces can later be retrieved
        List<LayerImage> LayerImageList; // List of Layer objects
        int zoomFactor;

        // Declare enum of layers. 
        // To declare additional layers, simply add a new entry in the enum.
        public enum Layers
        {
            Background,
            Star,
        }

        public CombinedLayers()
        {

            this.LayersList = new List<Bitmap> { };
            this.LayersIndeces = new List<Layers> { };

            // Initialises the LayersIndeces to contain the enums so the indices can later be retrieved
            // Also initialises the layerslist with empty transparent images
            foreach (Layers layer in (Layers[])Enum.GetValues(typeof(Layers)))
            {
                LayersIndeces.Add(layer);

                var newBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);
                newBitmap.MakeTransparent(Color.White);
                LayersList.Add(newBitmap);
            }



        }



        private void ShowCombinedLayers(PictureBox pictureBox)
        {
            // http://csharphelper.com/blog/2016/11/overlay-images-in-c/
            // Combines layers into a single image;
            CombinedBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);

            this.zoomFactor = 3;

            // Overlays the images of each layer
            using (Graphics gr = Graphics.FromImage(CombinedBitmap))
            {
                var location = new Point(0, 0);
                foreach (Image layer in LayersList)
                {
                    gr.DrawImage(layer, location);
                }
            }

            // Creates a larger version of the combined bitmap for display
            int zoomedWidth = Convert.ToInt32(Form1.IMG_WIDTH * zoomFactor);
            int zoomedHeight = Convert.ToInt32(Form1.IMG_HEIGHT * zoomFactor);
            Bitmap zoomedCombinedBitmap = new Bitmap(zoomedWidth, zoomedHeight);

            using (Graphics gpu = Graphics.FromImage(zoomedCombinedBitmap))
            {
                gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                gpu.DrawImage(
                   CombinedBitmap,
                    new Rectangle(0, 0, zoomedWidth, zoomedHeight),
                    // destination rectangle 
                    0,
                    0,           // upper-left corner of source rectangle
                    CombinedBitmap.Width,       // width of source rectangle
                    CombinedBitmap.Height,      // height of source rectangle
                    GraphicsUnit.Pixel);

                // Display the zoomed result.
                pictureBox.Image = zoomedCombinedBitmap;
            }
        }

        void UpdateLayer(Layers layer, Bitmap bitmap)
        {
            // retrieves the index of the Layers.Background enum in LayersIndeces
            int bgIndex = LayersIndeces.IndexOf(layer);

            // Replaces the image in the layersList to the new bitmap
            LayersList[bgIndex] = bitmap;

            // Updates the image shown in the picture box
            //ShowCombinedLayers();
        }
    }
}
